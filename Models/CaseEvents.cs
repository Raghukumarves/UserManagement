using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UserManagement.Models.Reports
{
    public class CaseEvents
    {
        public string esrId {  get; set; }
        public List<PastEvent> pastEvents { get; set; }
        public List<PastEvent> pendingEvents { get; set; }
    }
    public class PastEvent
    {
      
        public string eventId { get; set; }
        public string previousEventId { get; set; }
        public string modelVersion { get; set; }
        public int eventTypeId { get; set; }

  
        public DateTime? dasReceivedDate { get; set; }
        public DateTime? createdDate { get; set; }
    }

}