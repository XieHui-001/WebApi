using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class LoginViewModle
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string pwd { get; set; }
    }
}