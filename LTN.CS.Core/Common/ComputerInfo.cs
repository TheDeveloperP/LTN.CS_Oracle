using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;

namespace LTN.CS.Core.Common
{
    public class ComputerInfo
    {
        /// <summary>网卡
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetNetCardMacAddress()
        {
            try
            {
                //获取网卡硬件地址 
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                //moc = null;
                //mc = null;
                moc.Dispose();
                mc.Dispose();

                return mac;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary>网卡
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetNetCardMacAddress2()
        {
            string mac = "网卡未配置";

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");

            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (mo["NetConnectionStatus"] != null && mo["NetConnectionStatus"].ToString() == "2")
                {
                    mac = mo["MacAddress"].ToString();
                    //mo.Dispose();
                    break;
                }
            }
            moc.Dispose();
            mc.Dispose();

            return mac;
        }

        /// <summary>计算机名
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            try
            {
                //return System.Environment.GetEnvironmentVariable("ComputerName");
                return Dns.GetHostName();
                //return System.Environment.MachineName;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary>CPU序列号代码
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCpuID()
        {
            try
            {
                //获取CPU序列号代码 
                string cpuInfo = "";//cpu序列号 
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary>获取IP地址
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            try
            {
                //获取IP地址 
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString(); 
                        Array ar = (Array)(mo.Properties["IpAddress"].Value);
                        st = ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary>获取硬盘ID
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetDiskID()
        {
            try
            {
                //获取硬盘ID 
                String HDid = "";
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    HDid = (string)mo.Properties["SerialNumber"].Value;
                }
                moc = null;
                mc = null;
                return HDid;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary> 操作系统的登录用户名 
        /// 
        /// </summary> 
        /// <returns></returns> 
        public static string GetUserName()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    st = mo["UserName"].ToString();
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary> PC类型 
        /// 
        /// </summary> 
        /// <returns></returns> 
        public static string GetSystemType()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["SystemType"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
        }

        /// <summary> 物理内存
        ///  
        /// </summary> 
        /// <returns></returns> 
        public static string GetTotalPhysicalMemory()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    st = mo["TotalPhysicalMemory"].ToString();
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
        }
    }
}
