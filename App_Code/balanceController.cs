using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for balanceController
/// </summary>
public class balance
{
    public balance()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    static SMSDataClassesDataContext db;

    static long id(string account)
    {
        var acnt = (from i in db.SMS_eMoneys.Where(i => i.Account == account && i.Status == true) select i).Take(1).FirstOrDefault();
        if (acnt != null)
        {
            return acnt.ID;
        }
        return 0;
    }

    static string reply(string status)
    {
        var rep = (from i in db.SMS_Replies.Where(i => i.Tagged_ID == "BAL" && i.Status == status) select i).Take(1).FirstOrDefault();
        if (rep != null)
        {
            return rep.Message;
        }
        return null;
    }

    public static double current_amount(string account)
    {
        db = new SMSDataClassesDataContext();
        var acnt =

            (
                from d in db.SMS_VirtualMoneys.Where(d => d.type == 21 && d.account == account)
                select d.amount
            ).Sum() -
            (
                from d in db.SMS_VirtualMoneys.Where(d => d.type == 22 && d.account == account)
                select d.amount
            ).Sum();

        return (double)acnt;
    }

    public static bool Transaction(string account, string referenceNo, decimal amount, bool IsDeposit, int status)
    {
        db = new SMSDataClassesDataContext();
        SMS_VirtualMoney vMoney = new SMS_VirtualMoney();

        vMoney.refno = referenceNo;
        vMoney.account = account;
        if (IsDeposit){
            vMoney.type = 21;
        }
        else{
            vMoney.type = 22;
        }
        vMoney.amount = amount;
        vMoney.status = status;
        vMoney.datetime = config.current_DateTime();
        try{
            db.SMS_VirtualMoneys.InsertOnSubmit(vMoney);
            db.SubmitChanges();
            return true;
        }
        catch (Exception ex){
        }
        return false;
    }

    public static double IsQualified(string account)
    {
        return current_amount(account);
    }

    public static string check(string account)
    {
        string total = config.format_currency((decimal)current_amount(account));
        process.save(account, reply("OK").Replace("[AMOUNT]", total) + " " + DateTime.Now.ToLongDateString());
        return "OK";
    }
}