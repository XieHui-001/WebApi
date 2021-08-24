using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ResponseData
    {
        private string data_;

        public string data
        {
            get { return data_; }
            set { data_ = value; }
        }


        private string msg_;

        public string msg
        {
            get { return msg_; }
            set { msg_ = value; }
        }


        public int code { get; set; } = 200;


    }
}