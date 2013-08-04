using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for sqlServerController
/// </summary>
public class sqlServer
{
    static SqlConnection sqlCon;
	public sqlServer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static SMSDataClassesDataContext db = new SMSDataClassesDataContext();

    static bool Open()
    {
        sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SMSDatabaseConnectionString"].ConnectionString);
        try
        {
            if (!IsOpen)
            {
                sqlCon.Open();
                return true;
            }
        }
        catch (Exception ex)
        {}
        return false;
    }

    static bool IsOpen
    {
        get
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    static bool Close()
    {
        if (sqlCon.State == ConnectionState.Open)
        {
            sqlCon.Dispose();
            sqlCon.Close();
            return true;
        }
        else
        {
            return false;
        }
    }

    public static DataTable GetMemberInfo(string query)
    {
        Open();
        DataTable dt = new DataTable();
        SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
        try
        {
            dt = new DataTable("table");
            sqlDa.Fill(dt);
            dt = (dt.Rows.Count > 0) ? dt : null;
            if (IsOpen)
            {
                Close();
            }
        }
        catch (Exception ex)
        { }
        return dt;
    }

    public static string DateTime(string query)
    {
        Open();
        string refNo= "NULL";
        SqlCommand sqlCom = new SqlCommand(query, sqlCon);
        SqlDataReader sqlDr = sqlCom.ExecuteReader();
        try
        {
            if (sqlDr.Read())
            {
                refNo = sqlDr[0].ToString();
            }
            if (IsOpen)
            {
                Close();
            }
        }
        catch (Exception ex)
        { }
        return refNo;
    }

    public static Int64 Count(string table_name, string id)
    {
        Open();
        SqlCommand sqlCom = new SqlCommand("SELECT MAX(" + id + ") AS TOTAL_COUNT FROM " + table_name, sqlCon);
        SqlDataReader sqlDr = sqlCom.ExecuteReader();
        Int64 x = 0;
        try
        {
            if (sqlDr.Read())
            {
                x = (Int64)sqlDr[0];
            }
            if (IsOpen)
            {
                Close();
            }
        }
        catch (Exception ex)
        {}
        return x + 1;
    }

    public static bool Update(string command)
    {
        Open();
        SqlCommand sqlCom = new SqlCommand(command, sqlCon);
        try
        {
            sqlCom.ExecuteNonQuery();
            sqlCom.Dispose();
            if (IsOpen)
            {
                Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}