﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFCRUD
{
    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}