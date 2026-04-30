using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace DBtools
{
    public class Connector
    {
        private SqlConnection connection;

        public Connector(string connection_string)
        {
            connection = new SqlConnection(connection_string);
            Console.WriteLine(connection_string);
        }
        public DataTable Load(string cmd) 
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            connection.Close();
            return table;
        }
        public DataTable Select(string cmd, int interval = 4)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string[][] output = new string[1][];
            output[0] = new string[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
            {
                output[0][i] = $"[ {reader.GetName(i)} ]";
                table.Columns.Add(reader.GetName(i));
             }

            while (reader.Read())
            {
                output = output.Append(new string[reader.FieldCount]).ToArray();
                DataRow row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    output[output.Length - 1][i] = reader[i].ToString();
                    row[i] = reader[i];
                }
                table.Rows.Add(row);
            }
            reader.Close();
            connection.Close();

            for (int i = 0; i < output[0].Length; ++i)
            {
                int max_size_str = 0;
                for (int j = 0; j < output.Length; ++j)
                    if (max_size_str < output[j][i].Length) max_size_str = output[j][i].Length;

                for (int j = 0; j < output.Length; ++j)
                    output[j][i] = output[j][i].PadRight(max_size_str + interval);//+= new string(' ', max_size_str - output[j][i].Length + interval);
            }
            for (int i = 0; i < output[0].Length; ++i)
                Console.Write(output[0][i]);
            
            Console.WriteLine($"\n{new string('-', output[0].Sum(str => str.Length))}");

            for (int i = 1; i < output.Length;++i)
            {
                for(int j = 0; j < output[i].Length;++j)
                    Console.Write(output[i][j]);
                Console.WriteLine();
            }
            Console.WriteLine('\n');
            return table;
        }
        public DataTable Select(string fields, string tables, string condition = "", int interval = 4)
        {
            string cmd = $"SELECT {fields} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            return Select(cmd, interval);
        }

        public object Scalar(string cmd)
        {
            object value = null;
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            value = command.ExecuteScalar();
            connection.Close();
            return value;
        }
        public string GetPrimaryKeyColumnName(string table_name)
        {
            string cmd = $@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
                            WHERE CONSTRAINT_NAME=
                            (
                            SELECT	CONSTRAINT_NAME 
                            FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                            WHERE	TABLE_NAME= N'{table_name}'
                            AND		CONSTRAINT_TYPE = N'PRIMARY KEY'
                            );";

            return Scalar(cmd).ToString();
        }
        public int GetLastPrimaryKey(string table_name) =>
            (int)Scalar($"SELECT MAX({GetPrimaryKeyColumnName(table_name)}) FROM {table_name}");
        public int GetNextPrimaryKey(string table_name) =>
            GetLastPrimaryKey(table_name) + 1;


        public void Insert(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(string table, string fields, string values)
        {
            string[] split_fields = fields.Split(',');
            string[] split_values = values.Split(',');
            if (split_fields.Length != split_values.Length) return;
            string condition = "";

            for (int i = 1; i < split_fields.Length; ++i)
            {
                condition += $"{split_fields[i]} = {split_values[i]}";
                if (i != split_values.Length - 1) condition += " AND ";
            }
            if (Scalar($"SELECT {GetPrimaryKeyColumnName(table)} FROM {table} WHERE {condition}") == null)
                Insert($"Insert {table}({fields}) VALUES({values})");

        }
        public void Update(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(string table , string fields , string values , string condition) 
        {
            string[] s_fields = fields.Split(',');
            string[] s_values = values.Split(',');
            if (s_fields.Length != s_values.Length) return;
            string parsed = " ";
            for(int i = 0; i < s_fields.Length; i++) 
            {
                parsed += $"{s_fields[i]}={ParseValue(s_values[i])}";
                if (i != s_values.Length - 1) parsed += ',';
            }
            string cmd = $"UPDATE {table} SET {parsed} WHERE {condition}";
            if (Scalar($"SELECT {GetPrimaryKeyColumnName(table)} FROM {table} WHERE {parsed.Replace("," , " AND ")}") == null)
                Update(cmd);
        }

        string ParseValue(string value) 
        {
            if(value.Length > 1)
            {
                value = value.Trim(); // Метод удаляет пробелы в начале и в конце строки
                if (value[0] != 'N' && value[1] != '\'')
                    value = $"N'{value}'";
            }
                   
            return value;
        }
        public void UploadPhoto(byte[] image, int id , string field , string table) 
        {
            string cmd = $"UPDATE {table} SET {field}=@image WHERE {GetPrimaryKeyColumnName(table)}={id}";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@image", SqlDbType.VarBinary).Value = image;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Image DownloadPhoto(int id , string table , string field) 
        {
            //Image photo = null;
            //string cmd = $"SELECT {field} FROM {table} WHERE {GetPrimaryKeyColumnName(table)}={id}";
            //SqlCommand command = new SqlCommand(cmd, connection);
            //connection.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.Read()) 
            //{
            //    if (!reader.IsDBNull(0)) 
            //    {
            //        MemoryStream ms = new MemoryStream(reader[0] as byte[]);
            //        photo = Image.FromStream(ms);
            //        ms.Close();
            //    }
            //}
            //reader.Close();
            //connection.Close();
            //return photo;
            Image photo = null;
            object data = Scalar($"SELECT {field} FROM {table} WHERE {GetPrimaryKeyColumnName(table)}={id}");
            if (!Convert.IsDBNull(data)) 
            {
                MemoryStream ms = new MemoryStream(data as byte[]);
                photo = Image.FromStream(ms);
                ms.Close();
            }
            return photo;
        }
    }
}
