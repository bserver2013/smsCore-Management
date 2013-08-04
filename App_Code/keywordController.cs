using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for keywordController
/// </summary>
public class keyword
{
	public keyword()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string check(string number, string input)
    {
        string returnMsg = "Oops, please check your keyword, then try again! thank you...";
        returnMsg = help(number, input);
        if (returnMsg == "Null")
        {
            process.save(number, returnMsg);
            return "OK";
        }
        return "OK";
    }

    static string help(string number, string input)
    {
        string returnMsg = "Null";
        switch (input)
        {
            case "number":
            case "Number":
                returnMsg = "Number combination is 7-24! Maraming Salamat. Ugaliing magbigay ng tulong at Donasyong Barya, Sagip Buhay Ng Masa.";
                break;
            case "project":
            case "Project":
                returnMsg = "Ang inyong donasyon ngayon ay para sa mga nasalanta sa bagyong Harabas at pgpapatayo ng HOSPITAL NG MASA!";
                break;
            case "gateway ":
            case "Gateway ":
                returnMsg = "Gateway: Smart: 091823456789 | Globe: 0926 2345678 | Sun: 09321456789";
                break;
            case "help":
            case "Help":
                returnMsg = "1.To register: Reg FamilyName/FirstName/Address/SponsorCode/PinCode Send Gateway " +
                       "2.To donate: Number combination/amount Send gateway 3.To transfer fund: Tf RecepientNumber/amount/Purpose  Send gateway " +
                       "4.To know the winning number, text <Number> 5.To know the project, text <project>.Send Gateway";
                break;
            case "hotline":
            case "Hotline":
                returnMsg = "Call or Text 09164290916, 09182988888";
                break;
            case "reg":
            case "Reg":
                returnMsg = "Welcome to Bayanihan Damayan! Ibalik natin ang Bayanihang Filipino. U are given 100 points to share. " +
                       "Donasyong Barya, Sagip Buhay Ng Masa. To donate, type number combination/amount Send to gateway. ex. 2-46/2 Send. MAraming Salamat Po.";
                break;
            case "donate":
            case "Donate":
                returnMsg = "Natanggap namin ang iyong dalawang pisong tulong, your number is 14-25 ref # 013423.";
                break;
            case "weather":
            case "Weather":
                returnMsg = forecast.consume("http://weather.yahooapis.com/forecastrss?w=");
                break;
            default:
                returnMsg = internal_keyword(number, input);
                break;
        }
        return returnMsg;
    }

    static string internal_keyword(string number, string input)
    {
        string returnMsg = "Null";

        switch (input.Substring(0, 2))
        {
            case "TF":
            case "Tf":
            case "tf":
                return transfer.now(number, input);
        }

        switch (input.Substring(0, 3))
        {
            case "REG":
            case "Reg":
            case "reg":
                return SMS.Registration(number, input);
            case "BAL":
            case "Bal":
            case "bal":
                return balance.check(number);
        }

        switch (input.Substring(0, 6))
        {
            case "DONATE":
            case "Donate":
            case "donate":
                return donation.now(number, input);
        }

        return returnMsg;
    }
}