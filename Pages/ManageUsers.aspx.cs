using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Helpers;
using Newtonsoft;
using Newtonsoft.Json;
using UserManagement.Models;
using System.Data;
using System.Data.SqlClient;
using log4net;
namespace UserManagement.Pages
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(ManageUsers).ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    Logger.Info("Username is missing");
                    lblMsg.Text = Resources.ManagerUsers.EmptyUserName;
                    return;
                }
                
                var response = Common.DoGetWebRequest(string.Format(Constants.GetUserAPI, txtUserName.Text));
                Logger.Info("Search User Response for user :: " + txtUserName.Text + ": " + response);
                //response = "{\"mesUsersList\":[]}";
                if (string.IsNullOrEmpty(response))
                {
                    //Error
                    lblMsg.Text = Resources.ManagerUsers.APIErrorResponse;
                    ClearValues();
                    return;
                }
                MesUserData usersList = JsonConvert.DeserializeObject<MesUserData>(response);
                if (usersList == null)
                {
                    lblMsg.Text = Resources.ManagerUsers.APIErrorResponse;
                    ClearValues();
                    return;
                }
                if (usersList.MesUsersList != null && usersList.MesUsersList.Count > 0)
                {
                    dvUsersList.Visible = true;
                    grdUsersList.DataSource = usersList.MesUsersList;
                    grdUsersList.DataBind();
                    lblSearchText.Text = usersList.MesUsersList.Count.ToString() + " record(s) found for '" + txtUserName.Text.Trim() + "'";
                    Logger.Info(lblSearchText.Text);
                    lnkBtnAddUser.Visible = false;
                    dvNewUser.Visible = false;
                    lblLoginId.Text = string.Empty;
                    lblAddUserMsg.Text = string.Empty;
                    txtLoginId.Text = string.Empty;
                }
                else
                {
                    ViewState["NEWLOGIND"] = txtUserName.Text;
                    dvNewUser.Visible = true;
                    lnkBtnAddUser.Visible = true;
                    txtLoginId.Text = ViewState["NEWLOGIND"].ToString();
                    lblLoginId.Text = ViewState["NEWLOGIND"].ToString();
                    ClearValues();
                    //dvNewUser.Visible = false;
                    //lblLoginId.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void ClearValues()
        {
            dvUsersList.Visible = false;
            grdUsersList.DataSource = null;
            grdUsersList.DataBind();
            lblSearchText.Text = string.Empty;
            //txtLoginId.Text = string.Empty;
            txtEmpId.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;            
            //ddlDepartment.SelectedValue = "-1";
            //ddlDepartment.DataBind();
            //lblAddUserMsg.Text = string.Empty;

        }
        protected void GrdUsersList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)grdUsersList.Rows[e.RowIndex];
                string loginId = row.Cells[1].Text;
                //SqlCommand cmd = new SqlCommand("Delete From userTable (userName,age,birthPLace)");
                //grdUsersList.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        protected void GrdUsersList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm(\"Are you sure want to set this user to Inactive '" + item + "'?\")){ return false; };";
                    }
                }
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                modalDialog.Attributes.Remove("class");
                modalDialog.Attributes.Add("class", "modalactive");
                string validationMsg = ValidateAddUserInput();
                if (string.IsNullOrEmpty(validationMsg))
                {
                    MesUserRequest mesUserRequest = new MesUserRequest()
                    {
                        loginId = txtLoginId.Text,
                        firstName = txtFirstName.Text,
                        lastName = txtLastName.Text,
                        creationName = Session["USERNAME"].ToString(),
                        userId = Convert.ToInt32(txtEmpId.Text),
                        role = ddlRole.SelectedItem.Text
                    };
                    var createResponse = Common.DoPostWebRequest(Constants.AddUserAPI, JsonConvert.SerializeObject(mesUserRequest));
                    MesUserCreationResponse mesUser = JsonConvert.DeserializeObject<MesUserCreationResponse>(createResponse);
                    if (mesUser.status.ToUpper() == "SUCCESS")
                    {
                        lblAddUserMsg.Text = mesUser.description;
                        txtLoginId.Text = string.Empty;
                        lnkBtnAddUser.Visible = false;
                        dvNewUser.Visible = false;
                        lblLoginId.Text = string.Empty; 
                        ClearValues();
                    }
                    else if (mesUser.status == "FAILED")
                    {
                        lblAddUserMsg.Text = mesUser.description;
                    }
                }
                else
                {
                    lblAddUserMsg.Text = validationMsg;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }

            //lblAddUserMsg.Text = string.Empty;
        }

        private string ValidateAddUserInput()
        {
            if (string.IsNullOrEmpty(txtLoginId.Text))
            {
                return "LoginId is required";
            }            
            else if (string.IsNullOrEmpty(txtEmpId.Text))
            {
                return "Employee id is required";
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                return "LastName is required";
            }
            else if (string.IsNullOrEmpty(txtFirstName.Text))
            {
               return "FirstName is required";
            }
            return string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            modalDialog.Attributes.Remove("class");
            modalDialog.Attributes.Add("class", "modal");
            lblAddUserMsg.Text = "";
            ClearValues();
            txtLoginId.Text = string.Empty;
            lblAddUserMsg.Text = string.Empty;
            lnkBtnAddUser.Visible = false;
            dvNewUser.Visible = false;
            lblLoginId.Text = string.Empty;
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            modalDialog.Attributes.Remove("class");
            modalDialog.Attributes.Add("class","modal");
            lblAddUserMsg.Text = "";
            ClearValues();
            txtLoginId.Text = string.Empty;
            lblAddUserMsg.Text = string.Empty;
            lnkBtnAddUser.Visible = false;
            dvNewUser.Visible = false;
            lblLoginId.Text = string.Empty;
        }

        protected void lnkBtnAddUser_Click(object sender, EventArgs e)
        {
            modalDialog.Attributes.Remove("class");
            modalDialog.Attributes.Add("class", "modalactive");
            lblAddUserMsg.Text = "";
            ClearValues();
            txtLoginId.Text = string.Empty;
            lblAddUserMsg.Text = string.Empty;
            lnkBtnAddUser.Visible = false;
            dvNewUser.Visible = false;
            lblLoginId.Text = string.Empty;
        }
    }
}