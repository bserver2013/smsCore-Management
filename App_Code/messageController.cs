using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for messageController
/// </summary>
public class message
{
	public message()
	{
		//
		// TODO: Add constructor logic here
		//
	}

     int id = 0;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    string number = string.Empty;
    public  string Number
    {
        get { return number; }
        set { number = value; }
    }

    string msg = string.Empty;
    public  string Message
    {
        get { return msg; }
        set { msg = value; }
    }
}