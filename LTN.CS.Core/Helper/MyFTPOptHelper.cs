using EnterpriseDT.Net.Ftp;
using System;
using System.IO;
using System.Linq;


/****************************************************************
*   Copyright (c) 2018 江苏金恒,All rights reserved.
*   命名空间: LTN.CS.Base.Helper  
*   模块名称: MyFTPOptHelper 
*   作用：
*   作者：016523-kolio
*	创建时间：2019-3-12 19:24:43
*   修改历史：
*****************************************************************/
namespace LTN.CS.Core.Helper
{
    public static class MyFTPOptHelper
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ServerAddress"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="localPath"></param>
        /// <param name="remoteFile"></param>
        /// <param name="ServerPort"></param>
        /// <returns></returns>
        public static bool UploadFile(string ServerAddress, string UserName, string Password, string localPath, string remoteFile, out string msg, out string URL, int ServerPort = 21)
        {
            bool rs = false;
            FTPConnection ftpConnection1 = new FTPConnection();
            msg = string.Empty;
            URL = string.Empty;
            try
            {
                ftpConnection1.CommandEncoding = System.Text.Encoding.GetEncoding("gb2312");
                ftpConnection1.DataEncoding = System.Text.Encoding.UTF8;
                ftpConnection1.StrictReturnCodes = true;
                ftpConnection1.Timeout = 0;
                ftpConnection1.TransferBufferSize = 4096;
                ftpConnection1.TransferNotifyInterval = ((long)(4096));
                ftpConnection1.ServerAddress = ServerAddress;
                ftpConnection1.ServerPort = ServerPort;
                ftpConnection1.UserName = UserName;
                ftpConnection1.Password = Password;
                // Connect, get files and close
                ftpConnection1.Connect();
                ftpConnection1.UploadFile(localPath, remoteFile);
                rs = true;
                URL = ftpConnection1.GetURL()+ "/" + remoteFile;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (ftpConnection1 != null && ftpConnection1.IsConnected)
            {
                ftpConnection1.Close();
            }
            return rs;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ServerAddress"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="localPath"></param>
        /// <param name="remoteFile"></param>
        /// <param name="ServerPort"></param>
        /// <returns></returns>
        public static bool UploadFile(string ServerAddress, string UserName, string Password, string SavePath, Stream file, string remoteFile, out string msg, out string URL, int ServerPort = 21)
        {
            bool rs = false;
            FTPConnection ftpConnection1 = new FTPConnection();
            msg = string.Empty;
            URL = string.Empty;
            try
            {
                ftpConnection1.CommandEncoding = System.Text.Encoding.GetEncoding("gb2312");
                ftpConnection1.DataEncoding = System.Text.Encoding.UTF8;
                ftpConnection1.StrictReturnCodes = true;
                ftpConnection1.Timeout = 0;
                ftpConnection1.TransferBufferSize = 4096;
                ftpConnection1.TransferNotifyInterval = ((long)(4096));
                ftpConnection1.ServerAddress = ServerAddress;
                ftpConnection1.ServerPort = ServerPort;
                ftpConnection1.UserName = UserName;
                ftpConnection1.Password = Password;
                // Connect, get files and close
                ftpConnection1.Connect();
                SwitchWorkingDirectory(ftpConnection1, SavePath);
                ftpConnection1.UploadStream(file, remoteFile);
                rs = true;
                URL = ftpConnection1.GetURL() + "/" + remoteFile;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (ftpConnection1 != null && ftpConnection1.IsConnected)
            {
                ftpConnection1.Close();
            }
            return rs;
        }
        /// <summary>
        /// 切换目录
        /// </summary>
        /// <param name="ftpConnection1"></param>
        /// <param name="SavePath"></param>
        private static void SwitchWorkingDirectory(FTPConnection ftpConnection1, string SavePath)
        {
            var dir = SavePath.Split('/');
            if(dir != null)
            {
                foreach (var item in dir)
                {
                    if (!ftpConnection1.DirectoryExists(item))
                    {
                        ftpConnection1.CreateDirectory(item);
                    }
                    ftpConnection1.ChangeWorkingDirectory(item);
                }
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="ServerAddress"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="localPath"></param>
        /// <param name="remoteFile"></param>
        /// <param name="ServerPort"></param>
        /// <returns></returns>
        public static bool DownloadFile(string ServerAddress, string UserName, string Password, string localPath, string remoteFile, out string msg, int ServerPort = 21)
        {
            bool rs = false;
            FTPConnection ftpConnection1 = new FTPConnection();
            msg = string.Empty;
            try
            {
                ftpConnection1.CommandEncoding = System.Text.Encoding.GetEncoding("gb2312");
                ftpConnection1.DataEncoding = System.Text.Encoding.UTF8;
                ftpConnection1.StrictReturnCodes = true;
                ftpConnection1.Timeout = 0;
                ftpConnection1.TransferBufferSize = 4096;
                ftpConnection1.TransferNotifyInterval = ((long)(4096));
                ftpConnection1.ServerAddress = ServerAddress;
                ftpConnection1.ServerPort = ServerPort;
                ftpConnection1.UserName = UserName;
                ftpConnection1.Password = Password;
                // Connect, get files and close
                ftpConnection1.Connect();
                ftpConnection1.DownloadFile(localPath, remoteFile);
                rs = true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (ftpConnection1 != null && ftpConnection1.IsConnected)
            {
                ftpConnection1.Close();
            }
            return rs;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="ServerAddress"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="localPath"></param>
        /// <param name="remoteFile"></param>
        /// <param name="ServerPort"></param>
        /// <returns></returns>
        public static bool DownloadFile(string ServerAddress, string UserName, string Password, Stream file, string remoteFile, out string msg, int ServerPort = 21)
        {
            bool rs = false;
            FTPConnection ftpConnection1 = new FTPConnection();
            msg = string.Empty;
            try
            {
                ftpConnection1.CommandEncoding = System.Text.Encoding.GetEncoding("gb2312");
                ftpConnection1.DataEncoding = System.Text.Encoding.UTF8;
                ftpConnection1.StrictReturnCodes = true;
                ftpConnection1.Timeout = 0;
                ftpConnection1.TransferBufferSize = 40960;
                ftpConnection1.TransferNotifyInterval = ((long)(40960));
                ftpConnection1.ServerAddress = ServerAddress;
                ftpConnection1.ServerPort = ServerPort;
                ftpConnection1.UserName = UserName;
                ftpConnection1.Password = Password;
                // Connect, get files and close
                ftpConnection1.Connect();
                //SwitchWorkingDirectory(ftpConnection1, remoteFile);
                //int index = remoteFile.IndexOf(ServerAddress);
                //index += ServerAddress.Length + 1;
                //string dir = remoteFile.Substring(index);
                ftpConnection1.DownloadStream(file, remoteFile);
                rs = true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (ftpConnection1 != null && ftpConnection1.IsConnected)
            {
                ftpConnection1.Close();
            }
            return rs;
        }

    }
}
