using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for dataGridContoller
/// </summary>
public class dataGridContoller
{

    public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SMSDatabaseConnectionString"].ConnectionString;

    public dataGridContoller()
	{
	}

    static string members = "SELECT  "+
                            "  M.ID,   "+
                            "  M.ReferenceNo,  "+
                            "  M.Account_Number,  "+
                            "  M.Group_Name,  "+
                            "  M.Family_Name,  "+
                            "  M.First_Name,  "+
                            "  M.Town,  "+
                            "  M.Sponsor_ID,  "+
                            "  CONVERT(VARCHAR,CONVERT(MONEY, E.Amount),1) as Amount,  "+
                            "  M.Status  "+
                            "FROM SMS_Members AS M "+
                            "INNER JOIN SMS_eMoney AS E "+
                            "ON M.Account_Number = E.Account " +
                            "ORDER BY DateReg;";
    public static string Members
    {
        get { return members; }
    }

    static string inbox = "SELECT Id, Sender, Message, DateReceived FROM SMS_Inbox"; 
    public static string Inbox
    {
        get { return inbox; }
    }

    static string users = "SELECT ID, admin, role, email, date_added, added_by FROM SMS_User"; 
    public static string Users
    {
        get { return users; }
    }

    static string tfreports = "select ReferenceNo,Sender, Receiver," +
                              "CONVERT(VARCHAR,CONVERT(MONEY,Amount),1) as Amount, DateTransfered, Status " +
                              "from SMS_TransferFundReport";
    public static string Tfreports
    {
        get { return tfreports; }
    }

    static string damayan = "SELECT"+ 
	                        "   bayanihan_ref, "+
	                        "   CONVERT(varchar, CONVERT(MONEY, played), 1) AS played, "+
	                        "   CONVERT(varchar, CONVERT(MONEY, donation), 1) AS donations, "+
	                        "   combination_no_win, "+
	                        "   CONVERT(varchar, CONVERT(MONEY, total_win), 1) AS total_win, "+
                            "   CONVERT(varchar, CONVERT(MONEY, total_win_amount), 1) AS total_win_amount, " +
	                        "   open_started, "+
                            "   status " +
                            "FROM SMS_BayanihanSum ORDER BY open_started";
    public static string Damayan
    {
        get { return damayan; }
    }

    static string damayan_list = "SELECT " +
                                 "  refNo, " +
                                 "  donator, " +
                                 "  combination,  " +
                                 "  CONVERT(varchar, CONVERT(MONEY, donation), 1) AS donation, " +
                                 "  date_danated, " +
                                 "status " +
                                 "FROM SMS_Bayanihan";
    public static string Damayan_List(string id, string view)
    {
        if (view != "all")
        {
            return damayan_list + " WHERE bayanihan_ref = '" + id + "' AND status = '" + view + "'";
        }
        return damayan_list + " WHERE bayanihan_ref = '" + id + "'";
    }

    public static DataSet populate(string input)
    {
        DataSet ds = new DataSet();
        SqlConnection sqlCon = new SqlConnection(ConnectionString);
        SqlDataAdapter sqlDa = new SqlDataAdapter(input, sqlCon);

        ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
        sqlCon.Open();
        sqlDa.Fill(ds);
        sqlCon.Close();
        return ds;
    }
    
}