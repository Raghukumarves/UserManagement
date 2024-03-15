using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Helpers;
using UserManagement.Models.Reports;

namespace UserManagement.Pages.Reports
{
    public partial class ReplayEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected bool DispalyReplay(object columnValue)
        {
            if (Enum.IsDefined(typeof(OutBoundEvents), (int)columnValue))
                return true;

            return false;
        }
        
        protected void grdpastEventList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ReplayData")
            {
               
                ReplayEventRequest replayEventRequest = new ReplayEventRequest();
                replayEventRequest.eventId =e.CommandArgument?.ToString();


                var createResponse = Common.DoPostWebRequest(Constants.ReplayAPI, JsonConvert.SerializeObject(replayEventRequest));
                GetCaseEvents();
            }
        }
       

         protected void GetAllEvents_Click(object sender, EventArgs e)
        {
            GetCaseEvents();
        }

        private void GetCaseEvents()
        {
            string EsrId = ESRId.Text;

            var createResponse = Common.DoGetWebRequest(Constants.GetCaseAPI + EsrId);
            CaseEvents caseEventsResponse = JsonConvert.DeserializeObject<CaseEvents>(createResponse);
            grdpastEventList.DataSource = caseEventsResponse.pastEvents;
            if (caseEventsResponse.pastEvents.Count > 0)
            {
                Literal myText = new Literal()
                {
                    Text = "Past Events"
                };
                replayPastEventsHeader.Controls.Add(myText);

            }
            grdpastEventList.DataBind();
            grdpendingEventList.DataSource = caseEventsResponse.pendingEvents;
            if (caseEventsResponse.pendingEvents.Count > 0)
            {
                Literal myText = new Literal()
                {
                    Text = "Pending Events"
                };
                replayPendingEventsHeader.Controls.Add(myText);

            }
            else
            {
                Literal myText = new Literal()
                {
                    Text = "No Pending Events"
                };
                replayPendingEventsHeader.Controls.Add(myText);
            }
            grdpendingEventList.DataBind();
        }
    }
}