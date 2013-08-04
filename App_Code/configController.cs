using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for configController
/// </summary>
public class config
{
    public config()
	{
	}

    static string body_message1 = string.Empty;
    public static string Body_Message1
    {
        get { return body_message1; }
        set { body_message1 = value; }
    }

    static string body_message2 = string.Empty;
    public static string Body_Message2
    {
        get { return body_message2; }
        set { body_message2 = value; }
    }

    static string encoder = string.Empty;
    public static string Encoder
    {
        get { return encoder; }
        set { encoder = value; }
    }

    static bool flag = false;
    public static bool Flag
    {
        get { return flag; }
        set { flag = value; }
    }

    static bool isExcel = false;
    public static bool IsExcel
    {
        get { return isExcel; }
        set { isExcel = value; }
    }

    public enum prefixe
    {
        invalid_number = 5,
        invalid_prefix = 4,
        sun = 3,
        globe = 2,
        smart = 1
    }

    public static int prefixes(string number)
    {
        int net = (int)prefixe.invalid_number;

        if (number.Length == 11)
        {
            switch (number.Substring(0, 4))
            {
                case "0907":
                case "0908":
                case "0909":
                case "0910":
                case "0912":
                case "0918":
                case "0919":
                case "0920":
                case "0921":
                case "0928":
                case "0929":
                case "0930":
                case "0938":
                case "0939":
                case "0946":
                case "0947":
                case "0948":
                case "0949":
                case "0989":
                case "0998":
                case "0999":
                    net = (int)prefixe.smart; ;
                    break;
                case "0905":
                case "0906":
                case "0915":
                case "0916":
                case "0917":
                case "0925":
                case "0926":
                case "0927":
                case "0935":
                case "0936":
                case "0937":
                case "0994":
                case "0996":
                case "0997":
                    net = (int)prefixe.globe; ;
                    break;
                case "0922":
                case "0923":
                case "0932":
                case "0933":
                case "0934":
                case "0942":
                case "0943":
                    net = (int)prefixe.sun; ;
                    break;
                default:
                    net = (int)prefixe.invalid_prefix; ;
                    break;
            }
        }
        return net;
    }

    public static string format_currency(decimal amount)
    {
        return String.Format("{0:c}", amount).Replace("$", "");
    }

    static DateTime date_time()
    {
        return Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
    }

    public static DateTime current_DateTime()
    {
        string timeD = date_time().ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString();
        DateTime dc = Convert.ToDateTime(timeD);
        return dc;
    }

    const string _nums = "1234567890";
    public static string generateReferenceNo(int size)
    {
        Random _rng = new Random();
        char[] buffer = new char[size];
        for (int i = 0; i < size; i++)
        {
            buffer[i] = _nums[_rng.Next(_nums.Length)];
        }
        return new string(buffer);
    }

    const string _chars = "123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
    public static string generateReferenceNoWithCharacter(int size)
    {
        Random _rng = new Random();
        char[] buffer = new char[size];
        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[_rng.Next(_chars.Length)];
        }
        return new string(buffer);
    }

    public static bool email_validation(string email)
    {
        try
        {
            Regex rgx = new Regex(@"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$", RegexOptions.IgnoreCase);
            if (rgx.IsMatch(email))
            {
                return true;
            }
        }
        catch (FormatException)
        { }
        return false;
    }

    public static string email_UsernameAndPassword(string subject, string username, string password)
    {
        return "<!DOCTYPE html>" +
                "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                "<head>" +
                    "<style>" +
                        "body { margin-top: 0px; margin-left: 0px; margin-right: 0px; font-family: 'Segoe UI Semilight', 'Open Sans', Verdana, Arial, Helvetica, sans-serif; font-size: 12pt; } " +
                        ".header { float: left; width: 100%; height: 50px; background-color: #f1082e;}" +
                        ".header p { float: left; margin-top: 8px; margin-left: 12px; font-family: 'Segoe UI Semilight', 'Open Sans', Verdana, Arial, Helvetica, sans-serif; font-size: 16pt;letter-spacing: 0.01em; text-decoration:none;}" +
                        ".header p a {  color: #fff;  text-decoration:none; }" +
                        ".header small { font-size: 11pt; }" +
                        ".body { float: left; margin-top: -7px; padding: 5px; }" +
                        ".body h2 { float: left; margin-left: 0px;font-family: 'Segoe UI Light', 'Open Sans', Verdana, Arial, Helvetica, sans-serif;font-weight: 200;font-size: 17pt;letter-spacing: 0.01em;line-height: 22pt;font-smooth: always;color: #000000;}" +
                        ".body p{ float: left; margin-top: 60px; margin-left: -185px; }" +
                        ".subbody p{ float: left; margin-top:0; clear: both; padding-left: 5px; height: 200px; }" +
                        "#footer { width: 100%; margin: 0 auto;background-color:#fff;bottom:0;height:60px;clear: both;position: fixed;z-index: 10;margin-top:0;border-top: 1px solid #ccc;padding-top: 5px;}" +
                        "#footer .container { padding: 5px; }" +
                        "#footer .container .top { float: left; text-align: left; font-size: 13px; }" +
                        "#footer .container .top a { font-size: 13px; color: #f1082e; text-decoration: none; }" +
                        "#footer .container .top a:hover { text-decoration: underline; }" +
                    "</style>" +
                "</head>" +
                "<body>" +
                    "<div class='header'><p><a href='#'>SMSLauncher Management System <small>1.0.0</small></a></p></div>" +
                    "<div class='body'><h2> " + subject + " </h2></div>" +
                    "<div class='subbody'><p> Hi " + username + ", <br />here's your password: " + password + "</p></div>" +
                    "<div id='footer'><div class='container'><div class='top'>SMSLauncher Management &copy; " + DateTime.Now.Year + " <br /> Developed by <a href='http://facebook.com/kingpauloaquino' target='_blank'> KING PAULO AQUINO (iPaopaoworx) </a></div></div></div>" +
                "</body>" +
                "</html>";
    }

    public static bool send_email(string subject,string body, string email_to)
    {
        MailMessage mail = new MailMessage();
        mail.From = new System.Net.Mail.MailAddress("kingpauloaquino@gmail.com", "smsCore Management");

        // The important part -- configuring the SMTP client
        SmtpClient smtp = new SmtpClient();
        smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
        smtp.UseDefaultCredentials = false; // [3] Changed this
        smtp.Credentials = new NetworkCredential("kingpauloaquino@gmail.com", "kpa098765");  // [4] Added this. Note, first parameter is NOT string.
        smtp.Host = "smtp.gmail.com";

        //recipient address
        mail.To.Add(new MailAddress(email_to));
        mail.IsBodyHtml = true;
        mail.Subject = subject;
        mail.Body = body;
        try
        {
            smtp.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
        }
        return false;
    }

    static string pass = "ABC21abc";
    public static string encrypt(string input)
    {
        RijndaelManaged AES = new RijndaelManaged();
        MD5CryptoServiceProvider Hash_AES = new MD5CryptoServiceProvider();
        string encrypted = "";
        try
        {
            byte[] hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncryptor = AES.CreateEncryptor();
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(input);
            encrypted = Convert.ToBase64String(DESEncryptor.TransformFinalBlock(buffer, 0, buffer.Length));
        }
        catch (Exception ex)
        { }
        return encrypted;
    }

    public static string decrypt(string input)
    {
        RijndaelManaged AES = new RijndaelManaged();
        MD5CryptoServiceProvider Hash_AES = new MD5CryptoServiceProvider();
        string decrypted = "";
        try
        {
            byte[] hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecryptor = AES.CreateDecryptor();
            byte[] buffer = Convert.FromBase64String(input);
            decrypted = ASCIIEncoding.ASCII.GetString(DESDecryptor.TransformFinalBlock(buffer, 0, buffer.Length));
        }
        catch (Exception ex)
        { }
        return decrypted;
    }

}