using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Management;
using System.Text;
using System.Diagnostics;

public partial class dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("logout/");
        }

        lblWelUser.Text = Session["user"].ToString();
        hardwareController.loadCPU();
        lblCpuName.Text = hardwareController.CpuName;
        lblCpuName2.Text = hardwareController.CpuName;
        lblCpuUsaged.Text = hardwareController.CpuUsaged();
    }

    public static DateTime GetLastSystemShutdown()
    {
        string sKey = @"System\CurrentControlSet\Control\Windows";
        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey);

        string sValueName = "ShutdownTime";
        byte[] val = (byte[])key.GetValue(sValueName);
        long valueAsLong = BitConverter.ToInt64(val, 0);
        return DateTime.FromFileTime(valueAsLong);
    }

    public int interval = 0;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (interval == 1)
        {
            //lblCpuUsaged.Text = hardwareController.CpuUsaged();
            interval = 0;
        }
        interval++;
    }
}