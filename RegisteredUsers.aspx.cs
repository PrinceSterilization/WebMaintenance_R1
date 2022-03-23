using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using WebMaintenance.cls;




namespace WebMaintenance
{
    public partial class RegisteredUsers : System.Web.UI.Page
    {
        clsDB objDB = new clsDB();
        clsFormat objFormat = new clsFormat();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Identify User and Company
            //If User belongs to PSS and Admin, then show all Users
            //Else only Users of his company
            hdnAction.Value = "Show_Users";
        }
        protected void Page_Prerender(object sender, EventArgs e)
        {
            string strAction = hdnAction.Value;
            switch (strAction)
            {
                case "Show_Users":
                    {
                        SqlDataSource2.DataBind();
                        GridView1.DataBind();
                        MultiView1.ActiveViewIndex = 0;
                        hdnAction.Value = "";
                        break;
                    }
                case "Add_New_User":
                    {
                        MultiView1.ActiveViewIndex = 1;
                        hdnAction.Value = "";
                        break;
                    }
                case "Show_Details":
                    {
                        MultiView1.ActiveViewIndex = 1;
                        hdnAction.Value = "";
                        break;
                    }
                case "Show_Message":
                    {                        
                        MultiView1.ActiveViewIndex = 2;
                        hdnAction.Value = "";
                        break;
                    }
                case "Close_Message":
                    {
                        Show_Message(hdnErrorID.Value);
                        SqlDataSource2.DataBind();
                        GridView1.DataBind();
                        MultiView1.ActiveViewIndex = 0;
                        hdnAction.Value = "";
                        break;
                    }
                default:
                    {
                        MultiView1.ActiveViewIndex = -1;
                        hdnAction.Value = "";
                        break;
                    }
            }
        }
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCompany.SelectedValue != "0")
                {
                    string strSQL = "with TT1([ContactID],[Contact],[SponsorID]) as (SELECT [ContactID],[FirstName]+' '+[LastName] as'Contact'," +
                        "[SponsorID] FROM [PTS].[dbo].[Contacts] with(Nolock) where Active=1 and [SponsorID]!=127 union SELECT [UserID]'ContactID',[UserName]  as'Contact',130 as 'SponsorID' " +
                        "FROM [PTS].[dbo].[Users] where Active=1) Select [ContactID],[Contact] from TT1 where [SponsorID]='" + ddlCompany.SelectedValue + "'  order  by [Contact]";
                    ddlContact.Items.Clear();
                    objDB.PopulateDropDownList(strSQL, "ContactID", "Contact", ddlContact, "0", "Select Contact");
                    ddlContact.DataBind();
                }
                hdnAction.Value = "Show_Details";
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Validate User
            string strSQL = "Select count(Email) 'MyCount' from tblUser with(Nolock) where email='"+txtEmail.Text+"'";
            if (objDB.ValidateLog(strSQL, objDB.ConStrWeb) == true)
            {
                ////Encrypt data and Insert data to database
                Save_Record(hdnUsrID.Value);
                //Send Email
                string strEmailSender = "gyemets@princesterilization.com";
                string strEmailRecepient = txtEmail.Text;
                Send_Email(strEmailSender, strEmailRecepient);
                //Show Confirmation
                hdnErrorID.Value = "1";
                Show_Message(hdnErrorID.Value);
                hdnAction.Value = "Show_Message";
            }
            else
            {
                //Show Error
                hdnErrorID.Value = "2";
                Show_Message(hdnErrorID.Value);
                hdnAction.Value = "Show_Message";
            }
        }
        protected void Save_Record(string strID)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                hdnAction.Value = "Update";
                if (String.IsNullOrEmpty(strID) == true)
                {
                    hdnAction.Value = "Insert";
                }

                sb.Append("Execute sptblUserActions ");
                //ContactID,
                sb.Append("'" + ddlContact.SelectedValue + "', ");
                //Fname,
                string strContact = ddlContact.SelectedItem.Text;                
                var names = strContact.Split(' ');
                string firstName = names[0];
                sb.Append("'" + firstName.Trim() + "', ");
                //Lname,
                string lastName = names[1];
                sb.Append("'" + lastName.Trim() + "', ");
                //Email,
                sb.Append("'" + txtEmail.Text + "', ");
                //IsLocked,
                sb.Append("'False', ");
                //Pswrd,
                sb.Append("'" + objFormat.Encrypt("Welcome1", ConfigurationManager.AppSettings["SecurityKey"]) + "', ");
                //PswExpDate,
                sb.Append("'" + DateTime.Now.AddDays(3).Date + "', ");
                //AccessLvl,
                sb.Append("'" + optUserAccess.SelectedValue + "', ");
                //Ustatus,
                sb.Append("'" + optUserStatus.SelectedValue + "', ");
                //CompID,
                sb.Append("'" + ddlCompany.SelectedValue + "', ");
                //CompName,
                sb.Append("'" + ddlCompany.SelectedItem.Text + "', ");
                //CompStatus,
                sb.Append("'1', ");
                //Uorder,
                sb.Append("'0', ");
                //CreatedBy,
                sb.Append("'gyemets',");
                //CreatedDate,
                sb.Append("'" + DateTime.Today.ToShortDateString() + "', ");
                //LastModified,
                sb.Append("'gyemets',");
                //LastModifiedDate
                sb.Append("'" + DateTime.Today.ToShortDateString() + "', ");
                //Action 
                sb.Append("'" + hdnAction.Value + "' ");
                //sb.Append("'" + hdnAction.Value + "', ");
                ////P1 int strID
                //int intID = 0;
                //if (!string.IsNullOrEmpty(strID))
                //{
                //    intID = Convert.ToInt32(strID);
                //}
                ////InqID
                //sb.Append("'" + intID + "' ");

                string sqlQuery = sb.ToString();
                objDB.Execute_SP(sqlQuery, objDB.ConStrWeb);

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //[CompID]
            ddlCompany.Items.Clear();
            SqlDataSource1.DataBind();
            ddlCompany.DataBind();
            //ddlContact
            ddlContact.Items.Clear();
            //txtEmail
            txtEmail.Text = "";
            optUserStatus.SelectedValue = "2";
            optUserAccess.SelectedValue = "0";
            hdnAction.Value = "Show_Users";
        }
        protected void Send_Email(string strSenderEmail, string strRecepientEmail)
        {
            try
            {
                string strSQL = "Select Top 1 UsrID FROM [PTSWeb].[dbo].[tblUser] with (Nolock) where Email='" + strRecepientEmail + "'";
                string strP1 = objDB.GetParam(strSQL, "UsrID",objDB.ConStrWeb);
                //strP1 = "abc" + strP1;
                strP1 = objFormat.Encrypt(strP1, ConfigurationManager.AppSettings["SecurityKey"]);
                string strP2 = DateTime.Today.AddDays(Convert.ToInt32(ConfigurationManager.AppSettings["ExpirationInDays"])).ToShortDateString();
                strP2 = objFormat.Encrypt(strP2, ConfigurationManager.AppSettings["SecurityKey"]);

                StringBuilder sb = new StringBuilder();
                sb.Append("<p>Please follow the link to login to register and update password.<a href='"+ ConfigurationManager.AppSettings["RegistrationURL"] + "?p1="+ strP1 + "&p2=" + strP2 + "' target = '_blank'>Prince Sterlization - Web Maintenance</a></br>");
                sb.Append("Thank you.</br>");
                sb.Append("PSS Administrator</br>");
                sb.Append("(System generated e-mail)</p>");
                string strBody = sb.ToString();

                MailMessage mail = new MailMessage();
                mail.To.Add(strRecepientEmail);
                //mail.CC.Add(strUEMail);
                mail.From = new MailAddress(strSenderEmail);
                mail.Subject = "Email Request";
                mail.Body = strBody;
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "princesterilization-com.mail.eo.outlook.com";
                smtp.Send(mail);

            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            hdnErrorID.Value = "0";
            hdnAction.Value = "Close_Message";
        }
        protected void Show_Message(string strMsgID)
        {
            switch (strMsgID)
            {
                case "1":
                    {
                        lblHeader.Text = "Success";
                        lblMessage.Text = "New Record has been generated and emailed to User";
                        break;
                    }
                case "2":
                    {
                        lblHeader.Text = "Error";
                        lblMessage.Text = "User with this email address is already exists!";
                        break;
                    }
                default:
                    {
                        lblHeader.Text = "";
                        break;
                    }

            }
        
        }
        protected void Select_Record(object sender, CommandEventArgs e)
        {
            //Populate Details
            Populate_Details(e.CommandArgument.ToString());
            hdnAction.Value = "Show_Details";
        }
        protected void Populate_Details(string strUserID)
        {
            try
            {
                string strSQL = "SELECT [ContactID],[Email],[AccessLvl],[Ustatus],[CompID] FROM [PTSWeb].[dbo].[tblUser] with (Nolock) where UsrID='"+Convert.ToInt32(strUserID) + "'";
                _ = new DataTable();
                DataTable dt = objDB.myDT(strSQL, objDB.ConStrWeb);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //[CompID]
                    ddlCompany.Items.Clear();
                    SqlDataSource1.DataBind();
                    ddlCompany.DataBind();
                    ddlCompany.SelectedValue = dt.Rows[0][4].ToString();

                    //[ContactID],
                    string strSQL1 = "with TT1([ContactID],[Contact],[SponsorID]) as (SELECT [ContactID],[FirstName]+' '+[LastName] as'Contact'," +
                       "[SponsorID] FROM [PTS].[dbo].[Contacts] with(Nolock) where Active=1 and [SponsorID]!=127 union SELECT [UserID]'ContactID',[UserName]  as'Contact',130 as 'SponsorID' " +
                       "FROM [PTS].[dbo].[Users] where Active=1) Select [ContactID],[Contact] from TT1 where [SponsorID]='" + ddlCompany.SelectedValue + "'  order  by [Contact]";
                    ddlContact.Items.Clear();
                    objDB.PopulateDropDownList(strSQL1, "ContactID", "Contact", ddlContact, "0", "Select Contact", objDB.ConStr);
                    ddlContact.DataBind();
                    ddlContact.SelectedValue = dt.Rows[0][0].ToString();
                    //[Email],
                    txtEmail.Text= dt.Rows[0][1].ToString();
                    //[AccessLvl],
                    optUserAccess.SelectedValue= dt.Rows[0][2].ToString();
                    //[Ustatus],
                    optUserStatus.SelectedValue = dt.Rows[0][3].ToString();

                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void lbtnAddNew_Click(object sender, EventArgs e)
        {
            hdnAction.Value = "Add_New_User";
        }
    }
}