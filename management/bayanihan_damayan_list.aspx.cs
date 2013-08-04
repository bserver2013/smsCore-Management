using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_bayanihan_damayan_list : System.Web.UI.Page
{
    SMSDataClassesDataContext db;
    decimal totaldon = 0;
    decimal totalwin = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new SMSDataClassesDataContext();

        string view = "all";
        if (Request.QueryString["ref"] != null)
        {
            if (Request.QueryString["l"] != null)
            {
                view = Request.QueryString["l"];
            }
            gvbayanihan_list.DataSource = dataGridContoller.populate(dataGridContoller.Damayan_List(Request.QueryString["ref"], view));
            gvbayanihan_list.DataBind();

            var total = (from i in db.SMS_BayanihanSums.Where(i => i.bayanihan_ref == Request.QueryString["ref"]) select i).Take(1).FirstOrDefault();
            if (total != null)
            {
                totaldon = (decimal)total.donation;
                totalwin = (decimal)total.total_win_amount;
                txtTotalDon.Text = config.format_currency(totaldon) + "Php";
                lblTotalWin.Text = config.format_currency(totalwin) + "Php";

                if (total.donation != 0)
                {
                    lbUpdate.Visible = true;
                }

                if (total.status == "Closed")
                {
                    tbl_total.Visible = true;
                    lbUpdate.Visible = false;
                    links_id.Visible = true;
                }
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

            string refUrl = Request.QueryString["ref"];
            _all.Attributes.Add("href", "bayanihan_damayan_list.aspx?ref=" + refUrl);
            _winners.Attributes.Add("href", "bayanihan_damayan_list.aspx?ref=" + refUrl + "&l=Winner");
        }
        else
        {
            Response.Redirect("bayanihan_damayan.aspx");
        }
    }

    private int totalWon(string refNo, string winCode)
    {
        var winTotal = (from i in db.SMS_Bayanihans.Where(i => i.bayanihan_ref == refNo && i.combination == winCode) select i).Count();
        if (winTotal != null)
        {
           return winTotal;
        }
        return 0;
    }

    private float wonAllTotalAmount(string refNo, string winCode)
    {
        var winAmountTotal = (from i in db.SMS_Bayanihans.Where(i => i.bayanihan_ref == refNo && i.combination == winCode) select i.donation).Sum();
        if (winAmountTotal != null)
        {
           return (float)winAmountTotal;
        }
        return 0;
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        db = new SMSDataClassesDataContext();
        string refNo = Request.QueryString["ref"].Trim();
        string winCode = txtWinCode.Text.Trim();

        SMS_BayanihanSum d = new SMS_BayanihanSum();
        d.bayanihan_ref = "BD" + DateTime.Now.AddDays(1).ToString("Mddyyyy");
        d.played = 0;
        d.donation = 0;
        d.combination_no_win = "-";
        d.total_win = 0;
        d.total_win_amount = 0;
        d.open_started = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 01:00:00.000");
        d.closing_time = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 18:00:00.000");
        d.status = "Open";

        sqlServer.Update("UPDATE SMS_Bayanihan SET " +
                            "status = 'Winner'" +
                            "WHERE bayanihan_ref = '" + refNo + "' AND combination = '" + winCode + "'");

        sqlServer.Update("UPDATE SMS_BayanihanSum SET " +
                             "combination_no_win = '" + winCode + "', " +
                             "total_win = '" + totalWon(refNo, winCode) + "', " +
                             "total_win_amount = '" + wonAllTotalAmount(refNo, winCode) + "', " +
                             "status = 'Closed' " +
                             "WHERE bayanihan_ref = '" + refNo + "'");
        try
        {
            db.SMS_BayanihanSums.InsertOnSubmit(d);
            db.SubmitChanges();
        }
        catch (Exception ex)
        {
        }
        Response.Redirect(HelpController.Refresh);
    }


}