using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Resources;
using System.Reflection;
using ReaderB;
using System.IO.Ports;
using System.IO;

namespace RV.PM.ICcardMakeData
{
    public class RFIDAPI
    {
        private bool fAppClosed; //在测试模式下响应关闭应用程序
        private byte fComAdr = 0xff; //当前操作的ComAdr
        private int ferrorcode;
        private byte fBaud;
        private double fdminfre;
        private double fdmaxfre;
        private byte Maskadr;
        private byte MaskLen;
        private byte MaskFlag;
        private int fCmdRet = 30; //所有执行指令的返回值
        private int fOpenComIndex; //打开的串口索引号
        private bool fIsInventoryScan;
        private bool fisinventoryscan_6B;
        private byte[] fOperEPC = new byte[36];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[8];
        private int CardNum1 = 0;
        ArrayList list = new ArrayList();
        private bool fTimer_6B_ReadWrite;
        private string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）
        private int frmcomportindex;
        private bool ComOpen = false;
        int port = 0;

        public bool init()
        {
            fCmdRet = StaticClassReaderB.CloseSpecComPort(port);//关闭串口
            byte[] Parameter = new byte[6];
            Parameter[0] = Convert.ToByte(0);
            Parameter[1] = 0;
            Parameter[2] = 1;
            Parameter[3] = Convert.ToByte("02", 16);
            Parameter[4] = Convert.ToByte(1);
            Parameter[5] = 0;

            int openresult;
            openresult = 30;
            string mm = "FF";
            fComAdr = Convert.ToByte(mm, 16); // $FF;

            fBaud = Convert.ToByte(3);
            fBaud = Convert.ToByte(fBaud + 2);
            openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref fComAdr, fBaud, ref frmcomportindex);//端口初始化
            if (openresult != 0)
            {
                fCmdRet = StaticClassReaderB.CloseSpecComPort(port);//关闭串口
                MessageBox.Show("读卡器连接失败，请点击连接按钮重新连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                fCmdRet = StaticClassReaderB.SetWorkMode(ref fComAdr, Parameter, frmcomportindex);//读卡器设置
                return true;
            }
            //return Inventory();//读卡
        }
        public void close()
        {
            fCmdRet = StaticClassReaderB.CloseSpecComPort(port);//关闭串口
        }
        public string Inventory()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan = true;
            ListViewItem aListItem = new ListViewItem();
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;

            AdrTID = 0;
            LenTID = 0;
            TIDFlag = 0;
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if (CardNum != 1)
            {
                //fCmdRet = StaticClassReaderB.CloseSpecComPort(port);//关闭串口
                //MessageBox.Show("未读到卡或读到多张卡，请点击连接按钮重新连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return "";
                //
                sEPC = "";
            }
            //if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            //{
            else
            {
                m = 0;
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                EPClen = daw[m];
                sEPC = temps.Substring(m * 2 + 2, EPClen * 2);//EPC号
            }
            //}
            return sEPC;
        }
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }
        /// <summary>
        /// 写数据到卡的用户区
        /// </summary>
        public bool writedata(string rfid,string rowid)
        {
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte WNum = 0;
            byte EPClength = 0;
            byte Writedatalen = 0;
            int WrittenDataNum = 0;
            string s2, str;
            byte[] CardData = new byte[320];
            byte[] writedata = new byte[230];
            MaskFlag = 0;
            Maskadr = Convert.ToByte("00", 16);
            MaskLen = Convert.ToByte("00", 16);
            str = rfid;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            Mem = 3;
            WordPtr = Convert.ToByte("00", 16);
            Num = Convert.ToByte("6");
            fPassWord = HexStringToByteArray("00000000");
            s2 = rowid;
            WNum = Convert.ToByte(rowid.Length / 4);
            byte[] Writedata = new byte[WNum * 2];
            Writedata = HexStringToByteArray(s2);
            Writedatalen = Convert.ToByte(WNum * 2);
            fCmdRet = StaticClassReaderB.WriteCard_G2(ref fComAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, fPassWord, Maskadr, MaskLen, MaskFlag, WrittenDataNum, EPClength, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
