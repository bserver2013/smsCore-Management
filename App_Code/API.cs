using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for API
/// </summary>
public class API
{

    static SMSDataClassesDataContext db;
	public API()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string Secret_Access_ID
    {
        get;
        private set;
    }

    public static string Get_Access_Token(string email, string password)
    {
        db = new SMSDataClassesDataContext();
        var result = (from i in db.SMS_DevelopersAccounts.Where(i => i.email == email) select i).ToList();
        foreach (var m in result)
        {
            if (config.decrypt(m.password) == password)
            {
                Secret_Access_ID = m.secret_id;
                return m.access_token;
            }
        }
        return "Invalid developers account";
    }

    public static DataTable MembersInfo(string access_token, string number)
    {
        string query = "SELECT  " +
                            "  M.ID, " +
                            "  M.ReferenceNo, " +
                            "  M.Account_Number, " +
                            "  M.Group_Name, " +
                            "  M.Family_Name, " +
                            "  M.First_Name, " +
                            "  M.Town, " +
                            "  M.Sponsor_ID, " +
                            "  CONVERT(decimal(18, 2), E.Amount) as Amount, " +
                            "  M.Status  " +
                            "FROM SMS_Members AS M " +
                            "INNER JOIN SMS_eMoney AS E " +
                            "ON M.Account_Number = E.Account " +
                            "WHERE M.CP_Number = '" + number + "'" +
                            "ORDER BY DateReg;";
        return sqlServer.GetMemberInfo(query);
    }

    public bool Update_Member_Balance(string access_token, string number, decimal amount, string load_refno, string message_notification)
    {
        sqlServer.Update("UPDATE SMS_eMoney SET Amount = '" + amount + "' WHERE Account = " + number);
        return false;
    }
}