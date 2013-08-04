using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Management;
using System.Text;
using System.Diagnostics;

/// <summary>
/// Summary description for hardwareController
/// </summary>
public class hardwareController
{
	public hardwareController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string CpuName
    {
        get;
        set;
    }

    public static string MaxClockSpeed
    {
        get;
        set;
    }

    public static string Manufacturer
    {
        get;
        set;
    }

    public static string NumberOfCores
    {
        get;
        set;
    }

    public static string NumberOfProcessors
    {
        get;
        set;
    }

    public static string NumberOfLogicalProcessors
    {
        get;
        set;
    }

    public static string L2CacheSize
    {
        get;
        set;
    }

    public static string L3CacheSize
    {
        get;
        set;
    }

    public static string CpuUsaged()
    {
        PerformanceCounter cpuCounter = new PerformanceCounter();
        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";
        var unused = cpuCounter.NextValue();
        System.Threading.Thread.Sleep(1000);
        return cpuCounter.NextValue() + "%";
    }

    public static string MemoryUsaged()
    {
        PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        System.Threading.Thread.Sleep(1000);
        return ramCounter.NextValue() + "%";
    }

    public static void loadCPU()
    {
        using (ManagementObjectSearcher
                      win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                      win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                      win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"),
                      win32Local = new ManagementObjectSearcher("select * from Win32_LogicalDisk")
                      )
        {
            foreach (ManagementObject obj in win32Proc.Get())
            {
                CpuName = obj["Name"].ToString();
                MaxClockSpeed = obj["MaxClockSpeed"].ToString();
                Manufacturer  = obj["Manufacturer"].ToString();
                NumberOfCores  = obj["NumberOfCores"].ToString() + " Core";
                NumberOfLogicalProcessors = obj["NumberOfLogicalProcessors"].ToString();

                long l2 = Convert.ToInt64(obj["L2CacheSize"]);
                long l3 = Convert.ToInt64(obj["L3CacheSize"]);
                L2CacheSize = BytesToString(l2);
                L3CacheSize = BytesToString(l3);
            }
            foreach (var obj in win32CompSys.Get())
            {
                NumberOfProcessors = obj["NumberOfProcessors"].ToString();
            }
            //foreach (var obj in win32Memory.Get())
            //{
            //    long mem = Convert.ToInt64(obj["Capacity"]);
            //    j = "Memory Used: " + BytesToString(Convert.ToInt64(proc.PeakWorkingSet64)) +
            //        "<br />Physical Memory: " + BytesToString(mem) +
            //        "<br />Speed: " + obj["Speed"].ToString();
            //}
            //foreach (var obj in win32Local.Get())
            //{
            //    long local = Convert.ToInt64(obj["Size"]);
            //    l = "Free Space: " + BytesToString(local);
            //}
        }

    }

    private static String BytesToString(long byteCount)
    {
        string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
        if (byteCount == 0)
            return "0" + suf[0];
        long bytes = Math.Abs(byteCount);
        int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
        double num = Math.Round(bytes / Math.Pow(1024, place), 1);
        return (Math.Sign(byteCount) * num).ToString() + suf[place];
    }
}