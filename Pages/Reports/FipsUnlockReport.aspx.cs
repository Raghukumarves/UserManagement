using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Helpers;
using UserManagement.Models;
using UserManagement.Models.Reports;

namespace UserManagement.Pages.Reports
{
    public partial class FipsUnlockReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
           

        }
        
        protected void btnFipsUnlockGridClear_Click(object sender, EventArgs e)
        {
            grdUnlockList.DataSource = null;
            grdUnlockList.DataBind();
            hdnFips.Value = "";
            btnClear.Visible = false;

        }

        protected void btnFipsUnlock_Click(object sender, EventArgs e)
        {
            
            string caseNumbers = hdnFips.Value;
            FipsUnlockRequest unlockRequest = new FipsUnlockRequest();
            List<long> list = new List<long>();
            foreach (string caseNumber in caseNumbers.Split(','))
            {
                if (caseNumber != "")
                {  
                    if(caseNumber != "undefined")
                    list.Add(long.Parse(caseNumber));
                }
            }
            unlockRequest.vesNumbers = list;
            if (unlockRequest.vesNumbers.Count > 0)
            {
                var createResponse = Common.DoPostWebRequest(Constants.FipsUnlockAPI, JsonConvert.SerializeObject(unlockRequest));
                FipsUnlockResponse fipsUnlockResp = JsonConvert.DeserializeObject<FipsUnlockResponse>(createResponse);
                grdUnlockList.DataSource = fipsUnlockResp.fipsUnlockStatusList;
                if (fipsUnlockResp.fipsUnlockStatusList.Count > 0)
                {
                    Literal myText = new Literal()
                    {
                        Text = "Fips Unlock Status"
                    };
                    fipsUnlockHeader.Controls.Add(myText);
                    btnClear.Visible = true;
                }
                grdUnlockList.DataBind();
            }
        }
    }
}