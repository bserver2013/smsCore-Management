using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for messageController
/// </summary>
public class objectName
{
    public objectName()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // message

    public int Id { get; set; }
    public string Number { get; set; }
    public string Message { get; set; }

    // registration

    public string Group { get; set; }
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public string Town { get; set; }
    public string Province { get; set; }
    public string Sponsor { get; set; }
    public int Section_a { get; set; }
    public int Section_b { get; set; }
    public string Pin { get; set; }

}

public class objectColumn
{
    public string[] sqlDr = new string[99];
}