using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_users : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    protected void Page_Load(object sender, EventArgs e)
    {
        gvUsers.DataSource = dataGridContoller.populate(dataGridContoller.Users);
        gvUsers.DataBind();
        if (Session["role"] != null)
        {
            if (access.check_role(Session["role"].ToString()) == false)
            {
                gvUsers.Enabled = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Oops, You don't have permission to access this users page...";
            }
        }

        
    }

    protected void gvUsers_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "viewAccount") return;
        int id = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("user_edit.aspx?e=" + id);
    }
}