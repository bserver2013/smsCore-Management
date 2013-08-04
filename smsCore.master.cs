using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class smsCore : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            lblUsers.Text = Session["user"].ToString();
        }
        else
        {
            Response.Redirect("logout/");
        }
    }
}
