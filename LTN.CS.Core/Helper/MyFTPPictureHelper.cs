using DevExpress.XtraEditors;
using LTN.CS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Helper
{
    public static class MyFTPPictureHelper
    {
        public static string ServerAddress = "";
        public static string UserName = "admin";
        public static string Password = "123456";
        public static bool  PictureCustomUpLoad(Bitmap bmp,string directory, string remoteFile, out string msg, out string FileURL)
        {
            bool ret = false;
            msg = string.Empty;
            FileURL = string.Empty;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    ms.Position = 0;
                    if (MyFTPOptHelper.UploadFile(ServerAddress, UserName, Password, directory, ms, remoteFile, out msg, out FileURL))
                    {
                        ret = true;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ret;
        }

        public static bool PictureCustomUpLoad(MemoryStream ms, string directory, string remoteFile, out string msg, out string FileURL)
        {
            bool ret = false;
            msg = string.Empty;
            FileURL = string.Empty;
            try
            {
                if (MyFTPOptHelper.UploadFile(ServerAddress, UserName, Password, directory, ms, remoteFile, out msg, out FileURL))
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ret;
        }
        public static byte[] GetFTPPicture(string FTPPath)
        {
            byte[] result1 = null;
            if (!string.IsNullOrEmpty(FTPPath))
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        string msg = string.Empty;
                        bool rs = MyFTPOptHelper.DownloadFile(ServerAddress, UserName, Password, stream, FTPPath, out msg);
                        if (rs && stream != null)
                        {
                            result1 = stream.ToArray();
                            //using (MemoryStream ms = new MemoryStream(result1))
                            //{
                            //    ms.Position = 0;
                                
                            //}
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return result1;
        }
        public static void ShowFTPPicture(PictureEdit picShow, string FTPPath,string ServerAddress)
        {
            if (picShow.Image != null)
            {
                picShow.Image.Dispose();
                picShow.Image = null;
            }
            if (!string.IsNullOrEmpty(FTPPath))
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        string msg = string.Empty;
                        bool rs = MyFTPOptHelper.DownloadFile(ServerAddress, "admin", "123456", stream, FTPPath, out msg);
                        if (rs && stream != null)
                        {
                            byte[] result1 = stream.ToArray();
                            using (Stream ms = new MemoryStream(result1))
                            {
                                Bitmap bmtemp = new Bitmap(ms);
                                Image img = new Bitmap(bmtemp, picShow.Width, picShow.Height); //指定图片显示尺寸与控件大小一样
                                picShow.Visible = true;
                                picShow.EditValue = img;
                                //ms.Position = 0;
                                //picShow.Image = Image.FromStream(ms);
                            }
                            result1 = null;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}