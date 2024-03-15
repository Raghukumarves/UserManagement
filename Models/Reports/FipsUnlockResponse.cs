using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models.Reports
{
    public class FipsUnlock
    {
        public long vesNumber { get; set; }
        public string status { get; set; }
        public string message { get; set; }


    }
    public class FipsUnlockResponse
    {
        public List<FipsUnlock> fipsUnlockStatusList { get; set; }
    }
}