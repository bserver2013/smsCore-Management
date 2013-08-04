using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for processController
/// </summary>
public class process
{
	public process()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static SMSDataClassesDataContext db;

    static long _id = 0;
    public static long Id
    {
        get { return _id; }
        set { _id = value; }
    }

    static string _number = string.Empty;
    public static string Number
    {
        get { return _number; }
        set { _number = value; }
    }

    static string _message = string.Empty;
    public static string Message
    {
        get { return _message; }
        set { _message = value; }
    }

    public static bool now()
    {
        db = new SMSDataClassesDataContext();
        try
        {
            var receivedMsg = (from i in db.SMS_ReceivedMsgs.Where(i => i.Status == false) select i).Take(1).FirstOrDefault();
            if (receivedMsg != null)
            {
                switch (config.prefixes(receivedMsg.Sender))
                {
                    case 5:
                        delete(receivedMsg.Id);
                        break;
                    case 4:
                        delete(receivedMsg.Id);
                        break;
                    default:
                        keyword.check(receivedMsg.Sender, receivedMsg.Message);
                        delete(receivedMsg.Id);
                        break;
                }
                return true;
            }
        }
        catch (Exception ex)
        { }
        return false;
    }

    public static bool save(string number, string message)
    {
        if (message != "OK")
        {
            db = new SMSDataClassesDataContext();
            SMS_QueuedBox que = new SMS_QueuedBox();
            que.Message = config.encrypt(message);
            que.Number = number;
            que.Network = (short)config.prefixes(number);
            que.Status = false;

            try
            {
                db.SMS_QueuedBoxes.InsertOnSubmit(que);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            { }
        }
        return false;
    }

    public static bool delete(long id)
    {
        db = new SMSDataClassesDataContext();
        var x = (from i in db.SMS_ReceivedMsgs.Where(i => i.Id == id) select i).Take(1).FirstOrDefault();

        try
        {
            db.SMS_ReceivedMsgs.DeleteOnSubmit(x);
            db.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {}
        return false;
    }

    public static bool saveToSentItemThenDelete(long id, bool status)
    {
        db = new SMSDataClassesDataContext();
        SMS_SentItem sentItems = new SMS_SentItem();
        var x = (from i in db.SMS_QueuedBoxes.Where(i => i.ID == id) select i).Take(1).FirstOrDefault();
        if (x != null)
        {
            sentItems.Number = x.Number;
            sentItems.Message = x.Message;
            sentItems.DateTime = config.current_DateTime();
            sentItems.Status = status;
            sentItems.MonthOf = DateTime.Now.Month;
            sentItems.YearOf = DateTime.Now.Year;

            try
            {
                db.SMS_SentItems.InsertOnSubmit(sentItems);
                db.SMS_QueuedBoxes.DeleteOnSubmit(x);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {}
        }
        return false;
    }
}