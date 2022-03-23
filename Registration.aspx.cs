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
    public partial class Registration : System.Web.UI.Page
    {
        clsDB objDB = new clsDB();
        clsFormat objFormat = new clsFormat();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Page_Prerender(object sender, EventArgs e)
        {
            string strAction = hdnAction.Value;
            switch (strAction)
            {
                case "Close":
                    {
                        MultiView1.ActiveViewIndex = -1;
                        hdnAction.Value = "";
                        break;
                    }
                case "Registration":
                    {
                        
                        hdnAction.Value = "";
                        break;
                    }
                default:
                    {
                        //Validate entry params                
                        //By User ID               
                        string strP1 = Request.QueryString["p1"];
                        strP1 = objFormat.Decrypt(strP1, ConfigurationManager.AppSettings["SecurityKey"]);
                        //By Date
                        string strP2 = Request.QueryString["p2"];
                        strP2 = objFormat.Decrypt(strP2, ConfigurationManager.AppSettings["SecurityKey"]);
                        DateTime dt1 = Convert.ToDateTime(strP2);
                        DateTime dt2 = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                        int intExpired = dt1.Day - dt2.Day;
                        if (intExpired <= Convert.ToInt32(ConfigurationManager.AppSettings["ExpirationInDays"]))
                        {
                            //Validate User
                            hdnUsrID.Value = strP1;
                            //Populate Hello Label
                            string strSql = "Select [Fname]+' '+ [Lname] as Contact, [Email] FROM [PTSWeb].[dbo].[tblUser] with (Nolock) where [UsrID]='"+Convert.ToInt32(strP1)+"' and CompStatus=1 and Ustatus=2";
                            _ = new DataTable();
                            DataTable dt = objDB.myDT(strSql, objDB.ConStrWeb);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string strName = dt.Rows[0][0].ToString();
                                string strEmail = dt.Rows[0][1].ToString();
                                lblUserName.Text = "Hello " + strName + " (" + strEmail + ")";
                                MultiView1.ActiveViewIndex = 0;
                            }
                            else
                            {
                                lblHeader.Text = "Expired Request";
                                lblMessage.Text = "Your Registration Request is expired.<br/> Please contact Administrator to re-issue new registration email";
                                MultiView1.ActiveViewIndex = 1;
                            }                           

                        }
                        else
                        {
                            lblHeader.Text = "Expired Request";
                            lblMessage.Text = "Your Registration Request is expired.<br/> Please contact Administrator to re-issue new registration email";
                            MultiView1.ActiveViewIndex = 1;
                        }
                        break;
                    }

            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            hdnAction.Value = "Close";
        }

        protected void btnUpdatePsw_Click(object sender, EventArgs e)
        {
            //Insert tblUserQA
            //Update tblUser
            //Insert tblOldPsw

        }

        protected void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            //Clean Controls

            hdnAction.Value = "Close";
        }
    }
}