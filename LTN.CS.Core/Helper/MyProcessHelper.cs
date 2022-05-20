// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Core.Helper
// Author:kolio
// Created:2016/12/7 19:38:56
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/12/7 19:38:56
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LTN.CS.Core.Helper
{
    public static class MyProcessHelper
    {
        /// <summary>
        /// 获取当前正在运行的进程实例
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            // 获取当前活动的进程
            Process current = Process.GetCurrentProcess();
            // 获取当前本地计算机上指定的进程名称的所有进程
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            string rssTemp1 = Application.ExecutablePath;
            rssTemp1 = rssTemp1.Replace("vshost", "");
            rssTemp1=rssTemp1.Replace(".exe","");
            rssTemp1=rssTemp1.Replace(".EXE","");
            foreach (Process process in processes)
            {
                string rssTemp2 = process.MainModule.FileName;
                rssTemp2 = rssTemp2.Replace("vshost", "");
                rssTemp2=rssTemp2.Replace(".exe","");
                rssTemp2=rssTemp2.Replace(".EXE","");
                // 忽略当前进程
                if (process.Id != current.Id)
                {
                    if (rssTemp1 == rssTemp2)
                    {
                        return process;
                    }
                }
            }

            // 如果没有其他同名进程存在,则返回 null
            return null;
        }

        // 指示该属性化方法由非托管动态链接库 (DLL) 作为静态入口点公开
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;

        /// <summary>
        /// 如果有另一个同名进程启动,则调用之前的实例
        /// </summary>
        /// <param name="instance"></param>
        public static void HandleRunningInstance(Process instance)
        {
            // 确保窗体不是最小化或者最大化
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            // 将之前启动的进程实例弄到前台窗口
            SetForegroundWindow(instance.MainWindowHandle);
        }
    }
}
