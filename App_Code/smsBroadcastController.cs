using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for smsBroadcastController
/// </summary>
public class smsBroadcastController
{
	public smsBroadcastController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool process(string file, string bodyMessage1, string bodyMessage2, string encoder, bool flag, bool IsExcel)
    {
        bool OK = false;
        if (flag == true)
        {
            OK = textFile(file, bodyMessage1, bodyMessage2, encoder);
        }
        return OK;
    }

    public static bool textFile(string file, string bodyMessage1, string bodyMessage2, string encoder)
    {
        bool isOK = false;
        try
        {
            // Create an instance of StreamReader to read from a file. 
            // The using statement also closes the StreamReader. 
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                // Read and display lines from the file until the end of  
                // the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    short net = (short)prefixeController.prefixes(line.Replace("+63", "0"));
                    if (net != 5)
                    {
                        if (net != 4)
                        {
                            if (bodyMessage2 != string.Empty)
                            {
                                saveController.toQueuedbox(line, "1/2 " + bodyMessage1, net);
                                System.Threading.Thread.Sleep(100);
                                saveController.toQueuedbox(line, "2/2 " + bodyMessage2 + Environment.NewLine + Environment.NewLine + "encoded by: " + encoder, net);
                                isOK = true;
                            }
                            else
                            {
                                saveController.toQueuedbox(line, bodyMessage1 + Environment.NewLine + Environment.NewLine + "encoded by: " + encoder, net);
                                isOK = true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return isOK;
    }
}