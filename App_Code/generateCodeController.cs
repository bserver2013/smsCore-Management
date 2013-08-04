using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for generateCodeController
/// </summary>
public class generateCodeController
{
	public generateCodeController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private  readonly Random _rng = new Random();
    private const string _chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
    public string newCode(int size)
    {
        char[] buffer = new char[size];
        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[_rng.Next(_chars.Length)];
        }
        return new string(buffer);
    }

    public void save(string newCode)
    {
        try
        {
            SMSDataClassesDataContext db = new SMSDataClassesDataContext();
            SMS_ActivationCode sm;
            var chk = (from c in db.SMS_ActivationCodes.Where(c => c.PINCode == newCode) select c.PINCode).FirstOrDefault();
            if (chk == null)
            {
                sm = new SMS_ActivationCode();
                sm.PINCode = newCode;
                sm.Status = true;
                db.SMS_ActivationCodes.InsertOnSubmit(sm);
                db.SubmitChanges();
                Console.Write("<br />" + newCode);
            }
        }
        catch (Exception ex)
        {
        }
    }
}