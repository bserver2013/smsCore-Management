using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_inbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gvInbox.DataSource = dataGridContoller.populate(dataGridContoller.Inbox);
        gvInbox.DataBind();
    }

    protected void gvInbox_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        gvInbox.PageIndex = e.NewPageIndex;
        gvInbox.DataSource = dataGridContoller.populate(dataGridContoller.Inbox);
        gvInbox.DataBind();
    }

    protected void gvInbox_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "viewAccount") return;
        int id = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("inbox.aspx?id=" + id);
    }
}