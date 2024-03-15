using log4net;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Models;

namespace UserManagement
{
    public partial class CreateLoginUser : System.Web.UI.Page
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CreateLoginUser).ToString());
        public class UserDetails
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string DisplayName { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uName = Request.QueryString["name"];
                string pwd = Request.QueryString["pwd"];
                string dispName = Request.QueryString["dispname"];
                if (string.IsNullOrEmpty(uName) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(dispName))
                {
                    Response.Write("Invalid details");
                }
                else
                {
                    AddNewLoginUser(uName, pwd, dispName);

                }

            }
        }

        private void AddNewLoginUser(string uName, string pwd, string dispName)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["ADMINUSERDETAILS"];
                List<UserDetails> source = new List<UserDetails>();
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var usersList = JsonConvert.DeserializeObject<List<UserDetails>>(jsonData)
                                      ?? new List<UserDetails>();
                var userExists = usersList.FirstOrDefault(x => x.UserName == uName);
                if (userExists == null)
                {
                    // Add any new employees
                    usersList.Add(new UserDetails()
                    {
                        UserName = uName,
                        Password = pwd,
                        DisplayName = dispName
                    });

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(usersList);
                    System.IO.File.WriteAllText(filePath, jsonData);
                    sendEmail(uName);
                    Response.Write("User " + uName + " has been created");
                }
                else
                {
                    Response.Write("Username Already exists");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public static void sendEmail(string uName)
        {
            Logger.Info("Email Start");
            string SMTPServer = "";
            Logger.Info("Sendemail Start");
            SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
            string from = ConfigurationManager.AppSettings["from"];
            string to = ConfigurationManager.AppSettings["to"];
            string sub = "New User creation for Web App";
            try
            {

                char[] sep = { ';' };
                string[] toList = to.Split(sep);
                MailAddress _from = new MailAddress(from, "Donot Reply");
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                for (int i = 0; i < toList.Length; ++i)
                {
                    mail.To.Add(new MailAddress(toList[i]));
                }
                mail.From = _from;
                mail.Subject = sub;
                mail.IsBodyHtml = true;

                mail.Body = "New user with the user name '" + uName + "' has been created for web app";

                SmtpClient client = new SmtpClient(SMTPServer);
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                client.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
                mail.Priority = MailPriority.High;
                client.Send(mail);

                Logger.Info("Sendemail END");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
    }
}