using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LTN.CS.SCMHardSDK.LEDSDK
{
    public class Led5kstaticArea
    {
        public Led5kSDK.bx_5k_area_header header;
        public string text;
        public byte[] AreaToByteArray()
        {
            //计算header的大小：结构体bx_5k_area_header的大小
            Led5kSDK.bx_5k_area_header tu = new Led5kSDK.bx_5k_area_header();
            int hsz = Marshal.SizeOf(tu);

            //计算len的大小
            byte[] tmp = System.Text.Encoding.Default.GetBytes(text);
            int len = tmp.Length + hsz + 4;
            header.DataLen = tmp.Length;
            //先copy len
            byte[] bt = new byte[len];
            //byte[] lenToByte = System.BitConverter.GetBytes(len);
            byte[] lenToByte = System.BitConverter.GetBytes(len);
            lenToByte.CopyTo(bt, 0);
            int index = lenToByte.Length;

            //再copy header
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(hsz);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(header, structPtr, false);

            //从内存空间拷到AreaDataList数组
            Marshal.Copy(structPtr, bt, index, hsz);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //copy text
            tmp.CopyTo(bt, index + hsz);
            return bt;
        }
        public int getAreaLen()
        {
            Led5kSDK.bx_5k_area_header tu = new Led5kSDK.bx_5k_area_header();
            int hsz = Marshal.SizeOf(tu);
            //再考header

            byte[] tmp = System.Text.Encoding.Default.GetBytes(text);
            int len = tmp.Length + hsz + 4;
            return len;
        }
    }
}
