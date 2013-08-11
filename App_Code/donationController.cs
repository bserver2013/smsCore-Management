using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for donationController
/// </summary>
public class donation
{
	public donation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static SMSDataClassesDataContext db;

    static string Combination { get; set; }
    static double Donation { get; set; }

    static string reply(string status)
    {
        var rep = (from i in db.SMS_Replies.Where(i => i.Tagged_ID == "DONATE" && i.Status == status) select i).Take(1).FirstOrDefault();
        if (rep != null)
        {
            return rep.Message;
        }
        return null;
    }

    static bool IsSender_Exist(string account)
    {
        try
        {
            var acnt = (from i in db.SMS_Members.Where(i => i.CP_Number == account) select i).Take(1).FirstOrDefault();
            if (acnt != null)
            {
                return true;
            }
        }
        catch (Exception ex)
        { }
        return false;
    }

    static string check_If_open(DateTime value)
    {
        db = new SMSDataClassesDataContext();
        try
        {
            string query = "SELECT " +
                           "bayanihan_ref, " +
                           "CONVERT(DATE, open_started) AS 'OPEN DATE', " +
                           "CONVERT(TIME, open_started) AS 'OPEN TIME', " +
                           "CONVERT(TIME, closing_time) AS 'CLOSING TIME', " +
                           "CONVERT(DATE, GETDATE()) AS 'GET DATE', " +
                           "CONVERT(TIME, GETDATE() ) AS 'GET TIME' " +
                           "FROM SMS_BayanihanSum " +
                           "WHERE CONVERT(DATE, open_started) = CONVERT(DATE, GETDATE()) " +
                           "AND CONVERT(TIME, open_started) <= CONVERT(TIME, GETDATE()) " +
                           "AND CONVERT(TIME, closing_time) >= CONVERT(TIME, GETDATE());";
            string stat = sqlServer.DateTime(query);
            if (stat != "NULL")
            {
                return stat;
            }
            return "Closed";
        }
        catch (Exception ex)
        { }
        return "not available at this time!";
    }

    static int count_donators(string bayanihanRef)
    {
        db = new SMSDataClassesDataContext();
        try
        {
            var x = (from i in db.SMS_Bayanihans.Where(i => i.bayanihan_ref == bayanihanRef) select i).Count();
            return x;
        }
        catch (Exception ex)
        { }
        return 0;
    }

    static decimal total_donation(string bayanihanRef)
    {
        db = new SMSDataClassesDataContext();
        try
        {
            var x = (from i in db.SMS_Bayanihans.Where(i => i.bayanihan_ref == bayanihanRef) select i.donation).Sum();
            return (decimal)x;
        }
        catch (Exception ex)
        { }
        return 0;
    }

    public static string now(string number, string message)
    {
        db = new SMSDataClassesDataContext();
        string bayanihan = check_If_open(config.current_DateTime());
        if (IsSender_Exist(number))
        {
            if (bayanihan == "Closed" || bayanihan == "NULL")
            {
                process.save(number, "U hav reached the cut offtime to donate. ur entry isn't valid. try donating after 11pm 4 da nxt draw. Thank you!");
                return "OK";
            }

            string[] x = message.Split(' ');
            string[] y = x[1].Split('/');
            Donation = Convert.ToDouble(y[0]);
            Combination = y[1];
            string refCode = config.current_DateTime().ToString("MMdd") + config.generateReferenceNo(4);
            
            if (balance.current_amount(number) >= Donation)
            {
                SMS_Bayanihan b = new SMS_Bayanihan();
                b.refNo = refCode;
                b.bayanihan_ref = bayanihan;
                b.donator = number;
                b.combination = Combination;
                b.donation = (decimal)Donation;
                b.date_danated = config.current_DateTime();
                b.status = "-";

                try
                {
                    db.SMS_Bayanihans.InsertOnSubmit(b);
                    db.SubmitChanges();

                    sqlServer.Update("UPDATE SMS_BayanihanSum SET played = '" + count_donators(bayanihan) + "', " +
                                "donation = '" + total_donation(bayanihan) + "' " +
                                "WHERE bayanihan_ref = '" + bayanihan + "' AND status = 'Open';");

                    balance.Transaction(number, refCode, (decimal)Donation, false, 24);
                    process.save(number, reply("OK").Replace("[AMOUNT]", Donation.ToString()).Replace("[COMBINATION]", Combination).Replace("[BALANCE]", config.format_currency((decimal)balance.current_amount(number))).Replace("[REFNO]", refCode));
                    return "OK";
                }
                catch (Exception ex)
                {
                    process.save(number, "The system is not available at this time, please try again later");
                    return "OK";
                }
            }
            process.save(number, "Transaction cannot be processed because do to insufficient funds, to donate please reload now.");
            return "OK";
        }
        process.save(number, "You are not registerd in our record, please register first! thank you...");
        return "OK";
    }
}