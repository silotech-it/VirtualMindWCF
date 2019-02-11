using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WCFCRUDJson_Client.Models
{
    public class User
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Firstname")]
        public string firstname { get; set; }
        [Display(Name = "Lastname")]
        public string lastname { get; set; }
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}