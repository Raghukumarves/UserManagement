using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class MesUserRequest
    {
        public string loginId { get; set; }   
        public string firstName { get; set; }
        public string lastName { get; set; }    
        public string creationName { get; set; }
        public int userId { get; set; } = 0;
        public string role { get; set; }
    }
}