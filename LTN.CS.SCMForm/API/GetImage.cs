using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;

namespace LTN.CS.SCMForm.API
{
    public static class GetImage
    {
        public static Image getImageFromUrl(string url)
        {
            Image im = null;
            try
            {
                HttpWebRequest vHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                vHttpWebRequest.UnsafeAuthenticatedConnectionSharing = true;
                vHttpWebRequest.Timeout = 1500;
                HttpWebResponse vHttpWebResponse = (HttpWebResponse)vHttpWebRequest.GetResponse();

                BinaryReader vBinaryReader = new BinaryReader(vHttpWebResponse.GetResponseStream());
                MemoryStream vMemoryStream = new MemoryStream();
                byte[] vBuffer = new byte[0x1000];
                int vReadLength = vBinaryReader.Read(vBuffer, 0, vBuffer.Length);
                while (vReadLength > 0)
                {
                    vMemoryStream.Write(vBuffer, 0, vReadLength);
                    vReadLength = vBinaryReader.Read(vBuffer, 0, vBuffer.Length);
                }
                vHttpWebResponse.Close();
                vMemoryStream.Position = 0;
                im = Bitmap.FromStream(vMemoryStream);
                //vMemoryStream.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return im;
        }
    }
}
