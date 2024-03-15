using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class AdminUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get;set; }
    }
}