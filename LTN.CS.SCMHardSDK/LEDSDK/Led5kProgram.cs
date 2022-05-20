using System;
using System.Collections.Generic;
using System.Linq;

namespace LTN.CS.SCMHardSDK.LEDSDK
{
    public class Led5kProgram
    {
        public string name;
        public bool overwrite;

        public ushort DisplayType;
        public byte PlayTimes;

        public bool IsValidAlways;
        public ushort StartYear;
        public byte StartMonth;
        public byte StartDay;
        public ushort EndYear;
        public byte EndMonth;
        public byte EndDay;

        public byte ProgramWeek;

        public bool IsPlayOnTime;
        public byte StartHour;
        public byte StartMinute;
        public byte StartSecond;
        public byte EndHour;
        public byte EndMinute;
        public byte EndSecond;
        public byte AreaNum;
        public List<Led5kstaticArea> m_arealist = new List<Led5kstaticArea>();

        #region//转DCB码
        public static byte byte2bcd(byte num)
        {
            int i = num;
            return (byte)(i / 10 * 16 + i % 10);
        }
        public static byte bcd2byte(byte num)
        {
            int i = num;
            return (byte)(i / 16 * 10 + i % 16);
        }
        public static byte[] short2bcd(ushort num)
        {
            int i = num;
            byte high = (byte)(i / 100);
            byte low = (byte)(i % 100);
            byte[] tmp = new byte[2];
            tmp[0] = byte2bcd(low);
            tmp[1] = byte2bcd(high);
            return tmp;
        }
        #endregion

        public int SendProgram(uint hand)
        {

            byte[] ppFileName;
            byte[] ProgramLife;
            byte PlayPeriodGrpNum;
            byte[] Period;
            byte[] AreaDataList;
            int AreaDataListLen;

            int sum = 0;
            foreach (Led5kstaticArea s in m_arealist)
            {
                sum += s.getAreaLen();
            }
            AreaDataList = new byte[sum];
            int index = 0;
            foreach (Led5kstaticArea s in m_arealist)
            {
                byte[] bt = s.AreaToByteArray();
                bt.CopyTo(AreaDataList, index);
                index += bt.Length;
            }
            AreaDataListLen = sum;
            if (IsValidAlways == true)
            {
                ProgramLife = new byte[8];
                ProgramLife[0] = 0xff;
                ProgramLife[1] = 0xff;
                ProgramLife[2] = 0xff;
                ProgramLife[3] = 0xff;
                ProgramLife[4] = 0xff;
                ProgramLife[5] = 0xff;
                ProgramLife[6] = 0xff;
                ProgramLife[7] = 0xff;
            }
            else
            {

                ProgramLife = new byte[8];
                byte[] tmp = Led5kProgram.short2bcd(StartYear);
                ProgramLife[0] = tmp[0];
                ProgramLife[1] = tmp[1];
                ProgramLife[2] = byte2bcd(StartMonth);
                ProgramLife[3] = byte2bcd(StartDay);

                byte[] tmp1 = Led5kProgram.short2bcd(EndYear);

                ProgramLife[4] = tmp1[0];
                ProgramLife[5] = tmp1[1];
                ProgramLife[6] = byte2bcd(EndMonth);
                ProgramLife[7] = byte2bcd(EndDay);
            }


            ppFileName = System.Text.Encoding.Default.GetBytes(name);

            if (IsPlayOnTime == true)
            {
                Period = new byte[7];
                Period[0] = byte2bcd(StartHour);
                Period[1] = byte2bcd(StartMinute);
                Period[2] = byte2bcd(StartSecond);
                Period[3] = byte2bcd(EndHour);
                Period[4] = byte2bcd(EndMinute);
                Period[5] = byte2bcd(EndSecond);
                Period[6] = 0;

            }
            else
            {
                Period = null;
            }

            PlayPeriodGrpNum = Convert.ToByte(IsPlayOnTime ? 1 : 0);

            return Led5kSDK.OFS_SendFileData(hand, 1, ppFileName, DisplayType, PlayTimes, ProgramLife,
                ProgramWeek, PlayPeriodGrpNum, Period, AreaNum, AreaDataList, AreaDataListLen);
        }
    }
}
