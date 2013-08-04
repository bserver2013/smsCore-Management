using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
using System.Xml.Serialization;

/// <summary>
/// Summary description for forecastController
/// </summary>
public class forecast
{
	public forecast()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static SMSDataClassesDataContext db;

    static string city_selected()
    {
        db = new SMSDataClassesDataContext();
        var g = (from i in db.SMS_WeatherForecasts.Where(i => i.selected == true) select i).Take(1).FirstOrDefault();
        if (g != null)
        {
            return g.weather_code;
        }
        return "NULL";
    }

    static string read(string xmlString)
    {
        string temp = string.Empty;
        string condi = string.Empty;
        string weather = string.Empty;
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlString);

        XmlNodeList location = doc.GetElementsByTagName("yweather:location");
        foreach (XmlNode xNode in location)
        {
            XmlElement town = (XmlElement)xNode;
            weather = town.Attributes.GetNamedItem("city").InnerText + " " +
                    town.Attributes.GetNamedItem("country").InnerText + " Weather";
        }
        XmlNodeList condition = doc.GetElementsByTagName("yweather:condition");
        foreach (XmlNode xNode in condition)
        {
            XmlElement status = (XmlElement)xNode;
            condi = status.Attributes.GetNamedItem("text").InnerText;
            temp = status.Attributes.GetNamedItem("temp").InnerText;
        }

        string msg = weather + Environment.NewLine + condi + Environment.NewLine +
            " " + temp + "F | " + celcus(temp.Trim()).Substring(4) + "C";
        return msg;
    }

    static string celcus(string input)
    {
        float d = Convert.ToInt64(input) - 32;
        float c = d * 5 / 9;
        return c.ToString();
    }

    public static string consume(string url)
    {
        if (city_selected() != "NULL")
        {
            WebRequest request = WebRequest.Create(url + city_selected());
            try
            {
                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                return read(sr.ReadToEnd());
            }
            catch (WebException)
            { return "Oops, System is not available at this time... Please try again later! thank you.."; }
        }
        return "The weather it's being updated!";
    }
}