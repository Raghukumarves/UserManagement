using log4net;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Helpers;
using UserManagement.Models;
using UserManagement.Models.Reports;

namespace UserManagement.Pages.Reports
{
    public partial class MileageReport : System.Web.UI.Page
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(MileageReport).ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            try
            {
                var response = Common.DoGetWebRequest(Constants.MileageAPI);
                //var response = "{\r\n  \"mileageReportDataList\": [\r\n    {\r\n      \"control\": 0,\r\n      \"requestBy\": \"2024-02-21T14:09:17.888Z\",\r\n      \"total\": 0\r\n    }\r\n  ]\r\n}";
                Logger.Info("Mileage Report Response :: " + response);
                MileageReportResponse mileageReport = JsonConvert.DeserializeObject<MileageReportResponse>(response);
                if (mileageReport != null & mileageReport.mileageReportDataList != null && mileageReport.mileageReportDataList.Count > 0)
                {
                    btnExport.Visible = true;
                    grdUsersList.DataSource = mileageReport.mileageReportDataList;
                    grdUsersList.DataBind();
                }
                else
                {
                    btnExport.Visible = false;
                    grdUsersList.EmptyDataText = "No reports to display";
                    grdUsersList.DataBind();
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "VAMileageReport_" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                grdUsersList.GridLines = GridLines.Both;
                grdUsersList.HeaderStyle.Font.Bold = true;
                grdUsersList.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
        }

       
    }
}