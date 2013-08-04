using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_transfer_funds_reports : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new SMSDataClassesDataContext();
        gvtransferfundsreport.DataSource = dataGridContoller.populate(dataGridContoller.Tfreports);
        gvtransferfundsreport.DataBind();

        var total = (from i in db.SMS_TransferFundReports.Select(i => i.Amount) select i).Sum();
        if (total != null)
        {
            decimal x = (decimal)total;
            txtTotal.Text = config.format_currency(x) + "Php";
        }
        else
        {
            txtTotal.Text = "0.00Php";
        }
    }

    protected void gvtransferfundsreport_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        gvtransferfundsreport.PageIndex = e.NewPageIndex;
        gvtransferfundsreport.DataSource = dataGridContoller.populate(dataGridContoller.Tfreports);
        gvtransferfundsreport.DataBind();
    }

    protected void gvtransferfundsreport_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "ReferenceNo":
                Response.Redirect("transfer_funds_reports.aspx?ref=" + e.CommandArgument);
                break;
            case "Sender":
                Response.Redirect("transfer_funds_reports.aspx?s=" + e.CommandArgument);
                break;
            case "Receiver":
                Response.Redirect("transfer_funds_reports.aspx?r=" + e.CommandArgument);
                break;
        }
    }
}