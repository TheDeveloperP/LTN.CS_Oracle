using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace LTN.CS.Core.Helper
{
    public static class AESHelper
    {
        public static Dictionary<Guid, List<string>> keyCash = new Dictionary<Guid, List<string>>();

        public static string key = GetKey();

        public static string GetKey()
        {
            const string keyBase = "ABCDEFGHJKMNPQRSTWXYZabcdefhijkmnprstwxyz2345678";
            char[] keyBases = keyBase.ToCharArray();
            string key = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                int num = 20 + i * 7;
                num = num % 49 - 1;
                key += keyBases[num];
            }
            return key;
        }

        #region

        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] ivArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged() { Key = keyArray, IV = ivArray, Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string toDecrypt)
        {
            List<byte> blist = null;
            try
            {
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
                byte[] ivArray = UTF8Encoding.UTF8.GetBytes(key);
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                RijndaelManaged rDel = new RijndaelManaged() { Key = keyArray, IV = ivArray, Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                blist = new List<byte>();
                blist.AddRange(resultArray);
                for (int i = blist.Count - 1; i >= 0; i--)
                {
                    if (blist[i] == 0)
                    {
                        blist.RemoveAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
           
            return UTF8Encoding.UTF8.GetString(blist.ToArray());
        }

        public static string Decrypt(string toDecrypt, string keyStr, string ivStr)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(keyStr);
            byte[] ivArray = UTF8Encoding.UTF8.GetBytes(ivStr);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged() { Key = keyArray, IV = ivArray, Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            List<byte> blist = new List<byte>();
            blist.AddRange(resultArray);
            for (int i = blist.Count - 1; i >= 0; i--)
            {
                if (blist[i] == 0)
                {
                    blist.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            return UTF8Encoding.UTF8.GetString(blist.ToArray());
        }

        #endregion
    }
}
