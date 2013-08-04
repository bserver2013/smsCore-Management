using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_user_edit : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["e"] != null)
        {
            populate(Request.QueryString["e"]);
        }
    }

    public void populate(string id)
    {
        db = new SMSDataClassesDataContext();
        var x = (from i in db.SMS_Users.Where(i => i.ID == Convert.ToInt32(id)) select i).Take(1).FirstOrDefault();
        if (x != null)
        {
            txtUsername.Text = x.admin;
            txtEmail.Text = x.email;
            ddlRole.Text = x.role;
        }
    }
}