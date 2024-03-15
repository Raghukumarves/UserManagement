using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models.Reports
{
    public class MileageReportResponse
    {
        public List<MileageReportDataList> mileageReportDataList { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class MileageReportDataList
        {
            public long control { get; set; }
            public DateTime requestBy { get; set; }
            public long total { get; set; }
        }

    }
}