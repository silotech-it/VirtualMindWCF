using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFCRUDJson_Client.Models;

namespace WCFCRUDJson_Client.Viewmodels
{
    public class UserViewModel
    {
        public User user { get; set; }
    }

    public class UserViewModelList
    {
        public virtual ICollection<User> User { get; set; }
    }
}