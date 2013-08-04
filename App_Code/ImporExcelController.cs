using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

/// <summary>
/// Summary description for ImporExcelController
/// </summary>
public class ImporExcelController
{
   
    string strCon = ConfigurationManager.ConnectionStrings["SMSDatabaseConnectionString"].ConnectionString;
	public ImporExcelController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool delete()
    {
        bool oka = false;
        try
        {
            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand sqlCom = new SqlCommand("delete from SMS_Dummy", sqlcon);
            sqlcon.Open();
            sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            oka = true;
        }
        catch (Exception ex)
        {}
        return oka;
    }

    public bool exceldata(string filelocation)
    {
        try
        {
            string excelCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Excel 12.0 Xml;HDR=YES";
            string strExcel = "Select Reference_No, Group_Name, Account_No, Family_Name, First_Name, Town, Province, Sponsor_ID, CP_Number, Section_A, Section_B, DateReg, Status from [Sheet1$]";
            using (OleDbConnection oleCon = new OleDbConnection(excelCon))
            {
                OleDbCommand oleCom = new OleDbCommand(strExcel, oleCon);
                oleCon.Open();
                using (OleDbDataReader dr = oleCom.ExecuteReader())
                {
                    using (SqlBulkCopy sqlBC = new SqlBulkCopy(strCon))
                    {
                        sqlBC.ColumnMappings.Add("Reference_No", "Reference_No");
                        sqlBC.ColumnMappings.Add("Group_Name", "Group_Name");
                        sqlBC.ColumnMappings.Add("Account_No", "Account_No");
                        sqlBC.ColumnMappings.Add("Family_Name", "Family_Name");
                        sqlBC.ColumnMappings.Add("First_Name", "First_Name");
                        sqlBC.ColumnMappings.Add("Town", "Town");
                        sqlBC.ColumnMappings.Add("Province", "Province");
                        sqlBC.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
                        sqlBC.ColumnMappings.Add("CP_Number", "CP_Number");
                        sqlBC.ColumnMappings.Add("Section_A", "Section_A");
                        sqlBC.ColumnMappings.Add("Section_B", "Section_B");
                        sqlBC.ColumnMappings.Add("DateReg", "DateReg");
                        sqlBC.ColumnMappings.Add("Status", "Status");
                        sqlBC.DestinationTableName = "SMS_Dummy";
                        sqlBC.WriteToServer(dr);
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}