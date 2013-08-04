using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for receivedMessageController
/// </summary>
public class receivedMessage
{
	public receivedMessage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static SMSDataClassesDataContext db;
    public static bool save(string number, string message, bool process_now = false)
    {
        db = new SMSDataClassesDataContext();
        SMS_Inbox inbox = new SMS_Inbox();
        SMS_ReceivedMsg receivedMsg = new SMS_ReceivedMsg();

        inbox.Sender = number;
        inbox.Message = message;
        inbox.DateReceived = config.current_DateTime();
        inbox.MonthOf = DateTime.Now.Month;
        inbox.YearOf = DateTime.Now.Year;
        inbox.Status = false;

        receivedMsg.Sender = number;
        receivedMsg.Message = message;
        receivedMsg.DateReceived = config.current_DateTime();
        receivedMsg.MonthOf = DateTime.Now.Month;
        receivedMsg.YearOf = DateTime.Now.Year;
        receivedMsg.Status = false;

        try
        {
            db.SMS_Inboxes.InsertOnSubmit(inbox);
            db.SMS_ReceivedMsgs.InsertOnSubmit(receivedMsg);
            db.SubmitChanges();

            if (process_now)
            {
                process.now();
            }

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}