// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Helper
// Author:kolio
// Created:2016/11/6 22:07:14
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/6 22:07:14
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LTN.CS.Base.Helper
{
    public class MyIniHelper
    {
        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        private static string sPath = null;


        private MyIniHelper(string path)
        {
            MyIniHelper.sPath = path;
        }
        private static MyIniHelper iniObject { get; set; }
        public static MyIniHelper GetImplement()
        {
            if (iniObject==null)
            {
                string exePath = Application.StartupPath;
                exePath = String.Format("{0}\\exeIni.ini", exePath.TrimEnd('\\'));
                if (!File.Exists(exePath))
                {
                    StreamWriter sw = File.CreateText(exePath);
                    sw.Close();
                }
                iniObject = new MyIniHelper(exePath);
            }

            return iniObject;
        }

        public static void WriteValue(string section, string key, string value)
        {
            // section=配置节，key=键名，value=键值，path=路径
            MyIniHelper.GetImplement();
            WritePrivateProfileString(section, key, value, sPath);
        }


        public static string ReadValue(string section, string key)
        {
            try
            {
                MyIniHelper.GetImplement();
                // 每次从ini中读取多少字节
                System.Text.StringBuilder temp = new System.Text.StringBuilder(1500);

                // section=配置节，key=键名，temp=上面，path=路径
                GetPrivateProfileString(section, key, "", temp, 1500, sPath);
                return temp.ToString(); 
            }
            catch (Exception)
            {
                return string.Empty;
            }
           
        }

    }
}
