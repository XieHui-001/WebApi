using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Users
    {
        private string name;

        public string name_
        {
            get { return name; }
            set { name = value; }
        }

        private string sex;

        public string sex_
        {
            get { return sex; }
            set { sex = value; }
        }

        private int age;

        public int age_
        {
            get { return age; }
            set { age = value; }
        }


        private int zt;

        public int zt_
        {
            get { return zt; }
            set { zt = value; }
        }

        private int id_;

        public int ID
        {
            get { return id_; }
            set { id_ = value; }
        }

        private DateTime Birthday_;

        public DateTime Birthday
        {
            get { return Birthday_; }
            set { Birthday_ = value; }
        }


    }
}