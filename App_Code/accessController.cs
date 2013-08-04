using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for accessController
/// </summary>
public class access
{
    static SMSDataClassesDataContext db;
    public access()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool check_role(string role)
    {
        db = new SMSDataClassesDataContext();
        var x = (from i in db.SMS_Accessibilities.Where(i => i.role == role) select i).ToList();
        foreach (var l in x)
        {
            if (l.access == "users")
            {
                return true;
            }
        }
        return false;
    }
}