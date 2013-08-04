using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_members : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    protected void Page_Load(object sender, EventArgs e)
    {
        tblmanage.DataSource = dataGridContoller.populate(dataGridContoller.Members);
        tblmanage.DataBind();
    }

    protected void tblmanage_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        tblmanage.PageIndex = e.NewPageIndex;
        tblmanage.DataSource = dataGridContoller.populate(dataGridContoller.Members);
        tblmanage.DataBind();
    }

    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "viewAccount") return;
        int id = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("members.aspx?id=" + id);
    }

    protected void btnSearchAccount_Click(object sender, EventArgs e)
    {
        if (txtSeachAccount.Text != "Enter Act#, Ref# or Num")
        {
            if (txtSeachAccount.Text != string.Empty)
            {
                db = new SMSDataClassesDataContext();
                var getId = (from u in db.SMS_Members.Where(u => u.CP_Number == txtSeachAccount.Text || u.Account_Number == txtSeachAccount.Text || u.ReferenceNo == txtSeachAccount.Text) select u.ID).Take(1).FirstOrDefault();
                if (getId != 0)
                {
                    Response.Redirect("members.aspx?id=" + getId.ToString());
                }
            }
            else
            {
                Response.Redirect("members.aspx?e=null");
            }
        }
        else
        {
            Response.Redirect("members.aspx?e=no_given_value");
        }
    }
}