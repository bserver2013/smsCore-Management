using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for saveController
/// </summary>
public class saveController
{
    static SMSDataClassesDataContext db;
	public saveController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool toQueuedbox(string number, string message, short net)
    {
        db = new SMSDataClassesDataContext();
        SMS_QueuedBox que = new SMS_QueuedBox();
        que.Number = number;
        que.Message = config.encrypt(message);
        que.Network = net;
        que.Status = false;

        try
        {
            db.SMS_QueuedBoxes.InsertOnSubmit(que);
            db.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}