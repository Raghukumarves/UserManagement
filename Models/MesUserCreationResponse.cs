using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MesUser
    {
        public string loginId { get; set; }
        public string officeCode { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public object contactInfo { get; set; }
        public int mesGroup { get; set; }
        public string creationName { get; set; }
        public DateTime creationDate { get; set; }
        public string revisionName { get; set; }
        public DateTime revisionDate { get; set; }
        public int groupId { get; set; }
        public object userId { get; set; }
        public object hartfordOverride { get; set; }
        public object nycaseOverride { get; set; }
    }
    public class MesUserCreationResponse
    {
        public MesUser mesUser { get; set; }
        public string status { get; set; }
        public string description { get; set; }
    }
}