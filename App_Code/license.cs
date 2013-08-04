using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for license
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class license : System.Web.Services.WebService {

    public license () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool smsCore(string company, string type, string key)
    {
        if (company == "king.a")
        {
            if (type == "Pro-Standard")
            {
                if (key == "IKSN-5GDG-ND4S-456F")
                {
                    return true;
                }
            }
        }
        return false;
    }
    
}
