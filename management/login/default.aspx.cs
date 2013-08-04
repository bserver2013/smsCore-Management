using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_login_default : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new SMSDataClassesDataContext();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (Session["user"] != null)
        {
            Response.Redirect("../dashboard.aspx");
        }
        if (Session["send-password"] != null)
        {
            lblerr.Text = Session["send-password"].ToString();
            Session["send-password"] = null;
        }
        lblerr.Text = Guid.NewGuid().ToString();
    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        if (txtUser.Text != string.Empty)
        {
            if (txtPass.Text != string.Empty)
            {
                var result = (from i in db.SMS_Users.Where(i => i.admin == txtUser.Text) select i).Take(1).FirstOrDefault();
                if (result != null)
                {
                    if (config.decrypt(result.password) == txtPass.Text)
                    {
                        Session["role"] = result.role;
                        Session["user"] = txtUser.Text;
                        if (Session["notLogin"] != null)
                        {
                            Response.Redirect(Session["notLogin"].ToString());
                        }
                        Response.Redirect("../dashboard.aspx");
                    }
                    else
                    {
                        //head.InnerHtml = HelpController.notiLogin("Login");
                        lblerr.Text = "Whoops, Invalid password!";
                    }
                }
                else
                {
                    //head.InnerHtml = HelpController.notiLogin("Login");
                    lblerr.Text = "Whoops, Username did not found!";
                }
                
            }
            else
            {
                lblerr.Text = "Whoops, Invalid username or password!";
            }
        }
        else
        {
            lblerr.Text = "Whoops, Invalid username or password!";
        }
    }
    protected void btnRecovery_Click(object sender, EventArgs e)
    {
        if (txtID.Text != string.Empty)
        {
            var users = (from i in db.SMS_Users.Where(i => i.admin == txtID.Text) select i).Take(1).FirstOrDefault();
            if (users != null)
            {
                if (config.send_email("Password Recovery",
                    config.email_UsernameAndPassword("Password Recovery", users.admin, config.decrypt(users.password)), 
                    users.email)) {

                    Session["send-password"] = "Your request has been sent!";
                    Response.Redirect(HelpController.Refresh);
                }
                else
                {
                    lblerr.Text = "Oops, the system it not available at this time, please try again later!";
                }
            }
        }
        else
        {
            lblerr.Text = "Please enter your username.";
        }
    }
}