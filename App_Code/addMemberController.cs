using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Summary description for addMemberController
/// </summary>
public class addMemberController
{
    static SMSDataClassesDataContext db;
	public addMemberController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string requestRefenceNo
    {
        get
        {
            db = new SMSDataClassesDataContext();
            HelpController hc = new HelpController();
            string refN = "CIA" + hc.newRef(4) + "-" + DateTime.Now.Year;
            var getCount = (from x in db.SMS_Members.Where(x => x.ReferenceNo == refN) select x.ReferenceNo).Take(1).FirstOrDefault();
            if (getCount != null)
            {
                refN = "refresh";
            }
            return refN;
        }
    }

    public static bool saveNew(string refno, string group, string account, string lname, string fname,
                     string city, string province, int sec1, int sec2, string sponsor, string number)
    {
        short _sec1 = (short)sec1;
        short _sec2 = (short)sec2;
        SMS_Member sm = new SMS_Member();

        sm.ReferenceNo = refno;
        sm.Group_Name = group;
        sm.Account_Number = account;
        sm.Family_Name = lname;
        sm.First_Name = fname;
        sm.Town = city;
        sm.Province = province;
        sm.Sponsor_ID = sponsor;
        sm.CP_Number = number;
        sm.Section_A = _sec1;
        sm.Section_B = _sec2;
        sm.DateReg = HelpController.DateFormat(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + " " + DateTime.Now.ToShortTimeString());
        sm.monthOf = DateTime.Now.Month;
        sm.yearOf = DateTime.Now.Year;
        sm.Status = true;

        try
        {
            db.SMS_Members.InsertOnSubmit(sm);
            var emoney = db.SMS_eMoneys.Where(x => x.Account == number).FirstOrDefault();
            if (emoney == null)
            {
                SMS_eMoney money = new SMS_eMoney();
                money.Account = number;
                money.Amount = Convert.ToDecimal(100.00);
                money.Status = true;
                db.SMS_eMoneys.InsertOnSubmit(money);
            }
            db.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool checkUser(string number)
    {
        bool isExist = false;
        var users = db.SMS_Members.Where(x => x.CP_Number == number).FirstOrDefault();
        if (users != null)
        {
            isExist = true;
        }
        return isExist;
    }

}