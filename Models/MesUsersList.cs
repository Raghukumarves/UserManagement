using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class MesUsersList
    {
        public string LoginId { get; set; }
        public string OfficeCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactInfo { get; set; }
        public int MesGroup { get; set; }
        public string CreationName { get; set; }
        public string CreationDate { get; set; }
        public string RevisionName { get; set; }
        public string RevisionDate { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }
        public string HartfordOverride { get; set; }
        public string NycaseOverride { get; set; }
    }

    public class MesUserData
    {
        public List<MesUsersList> MesUsersList { get; set; }
    }
}