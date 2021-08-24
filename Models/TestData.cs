using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class TestData
    {
        [Required]
        //[EmailAddress]//邮箱验证
        [StringLength(100,MinimumLength = 5)]
        public string  name { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string pwd { get; set; }
    }
}