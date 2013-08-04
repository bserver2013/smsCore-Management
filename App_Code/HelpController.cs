using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Security.Cryptography;

/// <summary>
/// Summary description for HelpController
/// </summary>
public class HelpController
{
	public HelpController()
	{
		//
		// TODO: Add constructor logic here
		//

    }

    public static string notiLogin(string page_name)
    {
            string head = "<meta charset='utf-8' />" +
                          "  <meta name='viewport' content='target-densitydpi=device-dpi, width=device-width, initial-scale=1.0, maximum-scale=1' />" +
                          "  <meta name='description' content='' />" +
                          "  <meta name='author' content='kingpauloaquino@mail.com' />" +
                          "  <meta name='keywords' content='cms, windows 8, modern style, Metro UI, style, modern, css, framework' />" +
                          "  <link href='../css/modern.css' rel='stylesheet' />" +
   	                      "  <link href='../css/mystyle.css' rel='stylesheet' />" +
                          "  <script type='text/javascript' src='../js/jquery-1.9.1.js'></script>" +
                          "  <script type='text/javascript' src='../js/modern/dropdown.js'></script>" +
	                      "  <!-- Google WebFonts -->" +
	                      "  <link href='http://fonts.googleapis.com/css?family=PT+Sans:regular,italic,bold,bolditalic' rel='stylesheet' type='text/css' />" +
	                      "  <script type='text/css' src='javascripts/admin/modernizr-1.7.min.js'></script>" +
	                      "  <script type='text/javascript' src='../js/cms_script.js'></script>" +
	                      "  <script type='text/javascript' src='../js/customPaging.js'></script>" +
                          "  <title>SMSLauncher Management | " + page_name + "</title>" +
                          "  <script type='text/javascript'>" +
                          "    $('#noti').show();" +
                          "    $('#noti').fadeIn();" +
                          "    $('#noti').fadeOut(2000);" +
                          "    function block_sel(str) { localStorage.clickcount = str; }" +
                          "    function clear_cache() { localStorage.clickcount = 0; localStorage.cho = ''; }" +
                          "    function sub_cho(str) { localStorage.cho = str; }" +
	                      "  </script>";
            return head;
    }

    public static string _refresh = HttpContext.Current.Request.Url.AbsoluteUri;
    public static string Refresh
    {
        get { return _refresh; }
    }

    public static int toPopulate(int value)
    {
        int x = 1;
        switch (value)
        {
            case 0: x = 10; break;
            case 1: x = 50; break;
            case 2: x = 100; break;
            case 3: x = 100000; break;
        }
        return x;
    }

    private readonly Random _rng = new Random();
    private const string _chars = "09876543211234567890";
    public string newRef(int size)
    {
        char[] buffer = new char[size];
        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[_rng.Next(_chars.Length)];
        }
        return new string(buffer);
    }

    private static string _account = string.Empty;
    public static string Account
    {
        get { return _account; }
        set { _account = value; }
    }

    public static DateTime DateFormat(string input)
    {
        return DateTime.Parse(input);
    }

}