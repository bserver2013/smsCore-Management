using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for highChartController
/// </summary>
public class highChartController
{
	public highChartController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private static string _mem = string.Empty;
    public static string Memory
    {
        get { return _mem; }
        set { _mem = value; }
    }

    public static string execute(string type)
    {
        for (int i = 1; i <= 12; i++)
        {
            populate(i, type);
        }
        return "[ " + Memory + " ]";
    }

    static SMSDataClassesDataContext db;
    static void populate(int month, string type)
    {
        db = new SMSDataClassesDataContext();
        var get = (from i in db.SMS_Members.Where(i => i.monthOf == month && i.yearOf == DateTime.Now.Year) select i).Count();
        switch (type)
        {
            case "inbox" :
                get = (from i in db.SMS_Inboxes.Where(i => i.MonthOf == month && i.YearOf == DateTime.Now.Year) select i).Count();
                break;
            case "sentItem":
                get = (from i in db.SMS_SentItems.Where(i => i.MonthOf == month && i.YearOf == DateTime.Now.Year) select i).Count();
                break;
            case "registered":
                get = (from i in db.SMS_Members.Where(i => i.monthOf == month && i.yearOf == DateTime.Now.Year) select i).Count();
                break;
        }
        switch (month)
        {
            case 1:
                Memory = get.ToString() + ", ";
                break;
            case 2:
                Memory += get.ToString() + ", ";
                break;
            case 3:
                Memory += get.ToString() + ", ";
                break;
            case 4:
                Memory += get.ToString() + ", ";
                break;
            case 5:
                Memory += get.ToString() + ", ";
                break;
            case 6:
                Memory += get.ToString() + ", ";
                break;
            case 7:
                Memory += get.ToString() + ", ";
                break;
            case 8:
                Memory += get.ToString() + ", ";
                break;
            case 9:
                Memory += get.ToString() + ", ";
                break;
            case 10:
                Memory += get.ToString() + ", ";
                break;
            case 11:
                Memory += get.ToString() + ", ";
                break;
            case 12:
                Memory += get.ToString();
                break;
        }

    }
}