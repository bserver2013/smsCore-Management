using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
/// <summary>
/// Summary description for smsCore
/// </summary>
[WebService(Namespace = "http://fhsc.in")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class smsCore_api : System.Web.Services.WebService {

    string result;
    SMSDataClassesDataContext db;
    public smsCore_api()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "Send an SMS without validation")]
    public bool sendMethodWithoutValidation(string number, string message)
    {
        return receivedMessage.save(number, message);
    }

    [WebMethod(Description = "Send an SMS with validation")]
    public bool sendMethodWithValidation(string number, string message)
    {
        return receivedMessage.save(number, message, true);
    }

    [WebMethod(Description = "Get all message to be sent")]
    public messageList GetAllMessage()
    {
        db = new SMSDataClassesDataContext();
        messageList l = new messageList();
        var que = (from i in db.SMS_QueuedBoxes.Where(i => i.Status == false) select i).ToList();
        if (que != null)
        {
            foreach (var q in que)
            {
                message c = new message();
                c.Id = q.ID;
                c.Number = q.Number;
                c.Message = config.decrypt(q.Message);
                l.Add(c);
            }
            return l;
        }
        return null;
    }

    [WebMethod(Description = "Save all message sent to sent items")]
    public bool SentItems(int Id, bool IsSent)
    {
       return process.saveToSentItemThenDelete(Id, IsSent);
    }

    [WebMethod(Description = "Get member information then return it as string xml")]
    public string GetMemberInfo_StringXML(string access_token, string number)
    {
        DataTable dt = new DataTable("table");
        dt = API.MembersInfo(access_token, number);
        if (dt != null)
        {
            if (dt.Rows[0].ItemArray[0].ToString() == "-1")
            {
                result = dt.Rows[0].ItemArray[1].ToString();
            }
            else
            {
                StringWriter sw = new StringWriter();
                dt.WriteXml(sw);
                result = sw.ToString();
            }
        }
        return result;
    }

    [WebMethod(Description = "Get access token")]
    public string Get_Access_Token(string email, string password)
    {
        return API.Get_Access_Token(email, password);
    }

    [WebMethod(Description = "Get secret id")]
    public string Get_Secret_Id()
    {
        return API.Secret_Access_ID;
    }

    [WebMethod(Description = "Validate access token and secret id")]
    public string Check_AccessToken_and_SecretId(string access_token, string secret_id)
    {
        return "NOK";
    }

    [WebMethod(Description = "Get member information then return it as xml format")]
    public DataTable GetMemberInfo_XML(string access_token, string number)
    {
        return API.MembersInfo(access_token, number);
    }
    
}
