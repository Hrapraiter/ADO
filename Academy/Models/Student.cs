using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Academy.Models
{
    class Student:Human
    {
        internal int group;
        public Student
            (
            int id,
                string first_name, string midle_name,
                string last_name, string birth_date,
                string email, string phone, Image photo,
                int group
            ):base(id,first_name, midle_name,last_name, birth_date,email,phone,photo)
        {
            this.group = group;
        }
        public Student(Human human , int group) : base(human) 
        {
            this.group = group;
        }
        
        public override string GetNames() 
        {
            return base.GetNames() + ",[group]";
        }
        public override string GetValues()
        {
            return base.GetValues() + $",{group}";
        }
        public override string GetUpdateString()
        {
            return base.GetUpdateString() + $",[group]={group}";
        }


    }
    
}
