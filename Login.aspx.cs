using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Models;
using WebGrease;
using LogManager = log4net.LogManager;

namespace UserManagement
{
    public partial class Login : System.Web.UI.Page
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Login).ToString());
        private string adminUsersFile = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            txtUserId.Focus();
            if (ConfigurationManager.AppSettings["ADMINUSERDETAILS"] != null)
            {
                adminUsersFile = ConfigurationManager.AppSettings["ADMINUSERDETAILS"].ToString();
                Logger.Info("Admin User Path : " + adminUsersFile);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateUserInput())
                {
                    if (AuthenticateUser())
                    {
                        lblMsg.Text = "";
                        Session.Add("USERNAME", txtUserId.Text);
                        Response.Redirect("~/pages/manageusers.aspx");
                    }
                }
                Session.Clear();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Unable to process your request";
            }
        }

        private bool ValidateUserInput()
        {
            if (string.IsNullOrEmpty(txtUserId.Text))
            {
                lblMsg.Text = "Please enter username";
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Please enter password";
                return false;
            }
            return true;
        }
        private bool AuthenticateUser()
        {
            try
            {
                if (string.IsNullOrEmpty(adminUsersFile))
                {
                    //TODO log the information
                    lblMsg.Text = "Configurations missing";
                    return false;
                }
                if (!File.Exists(adminUsersFile))
                {
                    lblMsg.Text = "Configurations missing";
                    return false;
                }
                string readTex = File.ReadAllText(adminUsersFile);
                List<AdminUser> adminUsers = JsonConvert.DeserializeObject<List<AdminUser>>(readTex);
                if(adminUsers != null && adminUsers.Count > 0)
                {
                    AdminUser adminUser = adminUsers.SingleOrDefault(x=> x.UserName == txtUserId.Text.Trim() && x.Password == txtPassword.Text.Trim()); 
                    if (adminUser != null)
                    {
                        lblMsg.Text = "";
                        Session["DISPNAME"] = adminUser.DisplayName;
                        Session["USERNAME"] = txtUserId.Text;
                        return true;
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Credentials";                        
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}