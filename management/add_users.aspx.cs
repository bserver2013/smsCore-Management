using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class management_add_users : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (access.check_role(Session["role"].ToString()) == false)
            {
                btnSave.Enabled = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Oops, You don't have permission to access this users page...";
            }
        }

        if (Session["msg"] != null)
        {
            lblMsg.Visible = true;
            lblMsg.Text = Session["msg"].ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text != "")
        {
            if (txtPassword.Text != "")
            {
                if (txtPassword.Text == txtRePassword.Text)
                {
                    if (ddlRole.SelectedValue != "Select Role")
                    {
                        if (config.email_validation(txtEmail.Text))
                        {
                            Session["msg"] = add_user();
                            Response.Redirect(HelpController.Refresh);
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please enter a valid email...";
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Please select a role";
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Password and Re-type password did not match...";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please enter a password...";
            }
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please enter username...";
        }
    }

    private string add_user()
    {
        db = new SMSDataClassesDataContext();
        SMS_User u = new SMS_User();
        u.admin = txtUsername.Text;
        u.password = config.encrypt(txtPassword.Text);
        u.email = txtEmail.Text;
        u.role = ddlRole.SelectedValue;
        u.date_added = config.current_DateTime();
        u.added_by = Session["user"].ToString();

        try
        {
            db.SMS_Users.InsertOnSubmit(u);
            db.SubmitChanges();
            config.send_email("User Account",
                    config.email_UsernameAndPassword("User Account", txtUsername.Text, txtPassword.Text),
                    txtEmail.Text);
            return txtUsername .Text + " was successfully added!";
        }
        catch (Exception ex)
        { }
        return txtUsername.Text + " wasn't successfully added!";
    }
}