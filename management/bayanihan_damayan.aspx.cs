using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_bayanihan_damayan : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    decimal totaldon = 0;
    decimal totalwin = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new SMSDataClassesDataContext();
        gvbayanihan.DataSource = dataGridContoller.populate(dataGridContoller.Damayan);
        gvbayanihan.DataBind();

        var _totaldon = (from i in db.SMS_BayanihanSums.Where(i => i.status == "Closed" || i.status == "Open") select i.donation).Sum();
        var _totalwin = (from i in db.SMS_BayanihanSums.Where(i => i.status == "Closed" || i.status == "Open") select i.total_win_amount).Sum();
        if (totaldon != null && totalwin != null)
        {
            totaldon = (decimal)_totaldon;
            totalwin = (decimal)_totalwin;
            txtTotalDon.Text = config.format_currency(totaldon) + "Php";
            lblTotalWin.Text = config.format_currency(totalwin) + "Php";
        }
        else
        {
            txtTotalDon.Text = "0.00Php";
            lblTotalWin.Text = "0.00Php";
        }

        decimal xtotal = totaldon - totalwin;
        if (xtotal < 0)
        {
            lblTotalRem.Text = "<span style='color: #f61f33;'>" + xtotal + "Php</span>";
        }
        else
        {
            lblTotalRem.Text = xtotal + "Php";
        }
    }

    protected void gvbayanihan_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        gvbayanihan.PageIndex = e.NewPageIndex;
        gvbayanihan.DataSource = dataGridContoller.populate(dataGridContoller.Damayan);
        gvbayanihan.DataBind();
    }

    protected void gvbayanihan_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Bayanihan_Ref#":
                Response.Redirect("bayanihan_damayan_list.aspx?ref=" + e.CommandArgument);
                break;
        }
    }
}