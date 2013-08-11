using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for registrationController
/// </summary>
public class SMS
{
    public SMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static SMSDataClassesDataContext db;
    static objectList objList;

    static string populate(string input, string launcher_id)
    {
        string reg = input.Replace("REG ", "").Replace("Reg ", "").Replace("reg ", "");
        if (launcher_id == "BMC062013")
        {
            return bmc_reg(reg);
        }
        return bayanihan_reg(reg);
    }

    internal static string bayanihan_reg(string input)
    {
        objList = new objectList();
        string[] msg = input.Split('/');

        string code = string.Empty;
        for (int i = 0; i < msg.Length; i++)
        {
            objectName objName = new objectName();
            objName.Group = "BAYANIHAN";
            objName.Province = "N/A";
            objName.Section_a = 0;
            objName.Section_b = 0;
            switch (i)
            {
                case 0:
                    objName.Lastname = msg[i];
                    break;
                case 1:
                    objName.Firstname = msg[i];
                    break;
                case 2:
                    objName.Town = msg[i];
                    break;
                case 3:
                    objName.Sponsor = msg[i];
                    break;
                case 4:
                    objName.Pin = msg[i];
                    code = msg[i];
                    break;
            }
            objList.Add(objName);
        }
        return code;
    }

    internal static string bmc_reg(string input)
    {
        objList = new objectList();
        string[] msg = input.Split('/');
        string code = string.Empty;
        for (int i = 0; i < msg.Length; i++)
        {
            objectName objName = new objectName();
            switch (i)
            {
                case 0:
                    objName.Group = msg[i];
                    break;
                case 1:
                    objName.Lastname = msg[i];
                    break;
                case 2:
                    objName.Firstname = msg[i];
                    break;
                case 3:
                    objName.Town = msg[i];
                    break;
                case 4:
                    objName.Province = msg[i];
                    break;
                case 5:
                    objName.Sponsor = msg[i];
                    break;
                case 6:
                    objName.Section_a = Convert.ToInt32(msg[i]);
                    break;
                case 7:
                    objName.Section_b = Convert.ToInt32(msg[i]);
                    break;
                case 8:
                    objName.Pin = msg[i];
                    code = msg[i];
                    break;
            }
            objList.Add(objName);
        }
        return code;
    }

    static bool checkNumber(string number)
    {
        db = new SMSDataClassesDataContext();
        var member = (from i in db.SMS_Members
                      join e in db.SMS_eMoneys
                      on i.CP_Number equals e.Account
                      where i.CP_Number == number || e.Account == number
                      select i).Take(1).FirstOrDefault();

        if (member != null)
        {
            return true;
        }
        return false;
    }

    static bool checkCode(string input)
    {
        db = new SMSDataClassesDataContext();
        var code = (from i in db.SMS_ActivationCodes.Where(i => i.PINCode == input && i.Status == true) select i).Take(1).FirstOrDefault();
        if (code != null)
        {
            return code.Status;
        }
        return false;
    }

    static bool checkRef(string input)
    {
        db = new SMSDataClassesDataContext();
        var refNo = (from i in db.SMS_Members.Where(i => i.ReferenceNo == input) select i).Take(1).FirstOrDefault();
        if (refNo != null)
        {
            return true;
        }
        return false;
    }

    static string replyMessage(string tag, string status, string optional = "")
    {
        string reply = "Sorry, our system has encountered an error, please try again later. thank you!";
        db = new SMSDataClassesDataContext();
        var rep = (from i in db.SMS_Replies.Where(i => i.Tagged_ID == tag && i.Status == status) select i).Take(1).FirstOrDefault();
        if (rep != null)
        {
            if (status == "OK")
            {
                reply = rep.Message.Replace("[Firstname]", optional);
            }
            else
            {
                reply = rep.Message;
            }
        }
        return reply;
    }

    public static string Registration(string number, string input, string launcher_id)
    {
        db = new SMSDataClassesDataContext();

        if (checkNumber(number))
        {
            process.save(number, "Oop, Your number already exist to our record!PleasE try a new number");
            return "OK";
        }

        if (checkCode(populate(input, launcher_id)))
        {
            string MemberName = string.Empty;
            string refCode = "CIA" + number.Substring(1, 10) + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month;
            SMS_Member m = new SMS_Member();
            m.ReferenceNo = refCode;

            foreach (var l in objList)
            {
                MemberName = l.Firstname;
                m.Group_Name = l.Group;
                m.Account_Number = number;
                m.Family_Name = l.Lastname.ToUpper();
                m.First_Name = l.Firstname.ToUpper();
                m.Town = l.Town.ToUpper();
                m.Province = l.Province.ToUpper();
                m.Sponsor_ID = l.Sponsor;
                m.CP_Number = number;
                m.Section_A = (short)l.Section_a;
                m.Section_B = (short)l.Section_b;
                m.Pin_Code = l.Pin;
            }

            m.DateReg = config.current_DateTime();
            m.Status = true;
            m.monthOf = DateTime.Now.Month;
            m.yearOf = DateTime.Now.Year;

            try
            {
                db.SMS_Members.InsertOnSubmit(m);
                db.SubmitChanges();

                balance.Transaction(number, "CIA00001", 100, true, 25);
                process.save(number, replyMessage("NREG", "OK", MemberName));
                return "OK";
            }
            catch (Exception ex)
            {
                process.save(number, "Sorry, our system has encountered an error, please try again later. thank you!");
                return "OK";
            }
        }
        process.save(number, replyMessage("NREG", "NOK0"));
        return "OK";
    }
}