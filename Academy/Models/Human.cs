using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Academy.Models
{
    internal class Human
    {
        internal int id;
        internal string first_name;
        internal string middle_name;
        internal string last_name;
        internal string birth_date;
        internal string email;
        internal string phone;
        internal Image photo;

        public Human
            (
                int id,
                string first_name, string midle_name,
                string last_name, string birth_date,
                string email, string phone, Image photo
            )
        {
            this.id = id;
            this.first_name = first_name;
            this.middle_name = midle_name;
            this.last_name = last_name;
            this.birth_date = birth_date;
            this.email = email;
            this.phone = phone;
            this.photo = photo;
        }
        public Human(object[] values) 
        {
            id = Convert.ToInt32(values[0]);
            last_name = values[1].ToString();
            first_name = values[2].ToString();
            middle_name = values[3].ToString();
            birth_date = values[4].ToString();
            email = values[5].ToString();
            phone = values[6].ToString();

            byte[] imageBytes = Convert.IsDBNull(values[7]) ? new byte[0] : (byte[])values[7];
            if (imageBytes.Length < 1)return;
            
            photo = ConvertBytesToImage(imageBytes);
        }
        public Human(Human other)
        {
            this.id = other.id;
            this.first_name = other.first_name;
            this.middle_name = other.middle_name;
            this.last_name = other.last_name;
            this.birth_date = other.birth_date;
            this.email = other.email;
            this.phone = other.phone;
            this.photo = other.photo;
        }
        protected string ConvertImageToHex(Image image) 
        {
            string output = "";
            MemoryStream stream = new MemoryStream();
            
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();
            
            stream.Close();

            output = "0x" + BitConverter.ToString(imageBytes).Replace("-" , "");
            return output;
        }
        protected Image ConvertBytesToImage(byte[] imageBytes) 
        {
            using (MemoryStream stream = new MemoryStream(imageBytes))
                return Image.FromStream(stream);
        }
        public virtual string GetNames()
        {
            return "last_name,first_name,middle_name,birth_date,email,phone,photo";
        }
        public virtual string GetValues()
        {
            return $"N'{last_name}',N'{first_name}',N'{middle_name}',N'{birth_date}',N'{email}',N'{phone}',{ConvertImageToHex(photo)}";
        }
        public virtual string GetUpdateString() 
        {
            return 
                $"last_name=N'{last_name}'," +
                $"first_name=N'{first_name}'," +
                $"middle_name=N'{middle_name}'," +
                $"birth_date=N'{birth_date}'," +
                $"email=N'{email}'," +
                $"phone=N'{phone}'," +
                $"photo={ConvertImageToHex(photo)}";
        }
    }
}
