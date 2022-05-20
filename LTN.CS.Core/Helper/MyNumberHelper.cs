using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Helper
{
    public class MyNumberHelper
    {
        public static byte[] intToByte(int i)
        {

            byte[] abyte0 = new byte[4];

            abyte0[0] = (byte)(0xff & i);

            abyte0[1] = (byte)((0xff00 & i) >> 8);

            abyte0[2] = (byte)((0xff0000 & i) >> 16);

            abyte0[3] = (byte)((0xff000000 & i) >> 24);

            return abyte0;

        }

        public static int byteToInt(byte[] args)
        {
            return BitConverter.ToInt32(args,0); ;

        }
        /// <summary>
        /// 传入的字符型整数数字转换为数字整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ConvertToInt32(object input)
        {
            int rtn;

            bool flag = int.TryParse(Convert.ToString(input), out rtn);

            if (!flag)
                rtn = 0;

            return rtn;

        }
        // Get the exception type name; remove the namespace prefix.
        public static string GetExceptionType(Exception ex)
        {
            string exceptionType = ex.GetType().ToString();
            return exceptionType.Substring(
                exceptionType.LastIndexOf('.') + 1);
        }


        // Convert the decimal argument; catch exceptions that are thrown.
        public static int DecimalToU_Int32(decimal argument)
        {
            object Int32Value;
            object UInt32Value;

            // Convert the argument to an int value.
            try
            {
                Int32Value = (int)argument;
            }
            catch (Exception ex)
            {
                Int32Value = GetExceptionType(ex);
            }

            // Convert the argument to a uint value.
            try
            {
                UInt32Value = (uint)argument;
            }
            catch (Exception ex)
            {
                UInt32Value = GetExceptionType(ex);
            }

            return MyNumberHelper.ConvertToInt32(Int32Value);
        }

        /// <summary>
        /// 传入的字符型数字转换为数字型
        /// </summary>
        /// <param name="input">decimal</param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(object input)
        {
            decimal rtn;

            bool flag = decimal.TryParse(Convert.ToString(input), out rtn);
            if (!flag)
                rtn = 0;

            return rtn;

        }

        /// <summary>
        /// 传入的字符型数字转换为长整型数字
        /// </summary>
        /// <param name="input">long</param>
        /// <returns></returns>
        public static long ConvertToLong(object input)
        {
            long rtn;

            bool flag = long.TryParse(Convert.ToString(input), out rtn);

            if (!flag)
                rtn = 0;

            return rtn;

        }

        /// <summary>
        /// 传入的字符型数字转换为双精度型数字
        /// </summary>
        /// <param name="input">double</param>
        /// <returns></returns>
        public static double ConvertToDouble(object input)
        {
            double rtn;

            bool flag = double.TryParse(Convert.ToString(input), out rtn);

            if (!flag)
                rtn = 0;

            return rtn;

        }

        /// <summary>
        /// 传入的字符型数字转换为双精度型数字
        /// </summary>
        /// <param name="input">double</param>
        /// <returns></returns>
        public static ushort ConvertToUnShort(object input)
        {
            ushort rtn;

            bool flag = ushort.TryParse(Convert.ToString(input), out rtn);

            if (!flag)
                rtn = 0;

            return rtn;

        }
    }
}
