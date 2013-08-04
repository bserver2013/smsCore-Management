using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// Summary description for messageReturnContoller
/// </summary>
public class messageReturnContoller
{
	public messageReturnContoller()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable FormatDTReturn(int _flag, bool _result)
    {
        string result = "NOK";
        using (DataTable dt = new DataTable("table"))
        {
            if (_result)
            {
                result = "OK";
            }
            dt.Columns.Add("flag");
            dt.Columns.Add("result");
            dt.Rows.Add(_flag, result);
            return dt;
        }
    }
}