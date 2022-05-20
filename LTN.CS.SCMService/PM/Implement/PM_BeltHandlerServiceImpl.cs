using LTN.CS.SCMService.PM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMEntities.PM;
using System.Collections;
using LTN.CS.SCMDao.Common;
using IBatisNet.Common.Logging;
using System.Globalization;
using System.Windows.Forms;

using pSpaceCTLNET;

namespace LTN.CS.SCMService.PM.Implement
{
    public class PM_BeltHandlerServiceImpl : IPM_BeltHandlerService
    {
        public ICommonDao CommonDao { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        private DbConnector dbconnector;

        public void Login()
        {
            try
            {
                //string _serverName = "172.16.130.40";
                //string _serverName = "10.110.132.30";
                //string _serverName = "10.211.48.155";
                string _serverName = "10.200.112.155";

                string _userName = "admin";
                string _pwd = "admin888";
                pSpaceCTLNET.Common.StartAPI();
                dbconnector = new DbConnector();
                dbconnector.ServerName = _serverName;
                dbconnector.UserName = _userName;
                dbconnector.Password = _pwd;
                //DbError dr = dbconnector.Connect();
                if (!dbconnector.IsConnected())
                {
                    DbError err = dbconnector.Connect();
                    if (err.HasErrors)
                    {
                        MessageBox.Show("连接仪表失败---" + err.ErrorMessage);
                        Dispose();
                    }
                }
                //if (dbconnector)
                //{
                //    InserLog("连接仪表失败---" + dr.ErrorMessage);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库异常" + ex.Message);
                Dispose();
            }
        }

        public void Dispose()
        {
            if (dbconnector != null && dbconnector.IsConnected())
            {
                dbconnector.Disconnect();
                pSpaceCTLNET.Common.StopAPI();
                //InserLog("关闭仪表数据库连接");
            }
        }

        public List<PM_BeltTimeCount> getBeltRunTime(Hashtable ht)
        {
            List<PM_BeltTimeCount> list = new List<PM_BeltTimeCount>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("A202", "MT101VI01P");
            dic.Add("DK502", "SJ105VI01P");
            dic.Add("K105", "LT111VI01P");
            dic.Add("RJ1", "SJ107VI01P");
            dic.Add("GM302", "SJ109VI01P");
            dic.Add("GM501", "SJ110VI01P");
            dic.Add("A102", "MT102VI01P");
            dic.Add("GM202", "SJ108VI01P");
            dic.Add("JF7", "SJ117VI01P");
            dic.Add("A302", "MT103VI01P");
            dic.Add("Y101", "SJ116VI01P");
            dic.Add("Y201", "SJ114VI01P");
            dic.Add("LS101", "LT109VI01P");
            dic.Add("LS102", "LT108VI01P");
            dic.Add("BM104", "JH106VI01P");
            dic.Add("LJ101", "LT116VI01P");
            dic.Add("A402", "MT104VI01P");
            dic.Add("LJ103", "LT117VI01P");
            dic.Add("B502", "ZL108VI01P");
            dic.Add("B505", "ZL112VI01P");
            dic.Add("B506", "ZL113VI01P");
            dic.Add("J101", "LT112VI01P");
            dic.Add("J201", "LT113VI01P");
            dic.Add("KK5", "SJ106VI01P");
            dic.Add("GM401", "SJ111VI01P");
            dic.Add("成202", "SJ104VI01P");
            dic.Add("F101", "LT113VI01P");
            dic.Add("F201", "LT114VI01P");
            dic.Add("SJ102", "LT115VI01P");
            dic.Add("球团成一", "SJ203VI01P");
            dic.Add("成102", "SJ115VI01P");


            string startTime = ht["startTime"].ToString();
            string endTime = ht["endTime"].ToString();
            string beltNo = ht["beltNo"].ToString();//后续用于判断
            //int interval = Convert.ToInt32(ht["interval"].ToString());
            if (!string.IsNullOrEmpty(beltNo))
            {
                if (dic.ContainsKey(beltNo))
                {
                    PM_BeltTimeCount beltCount = new PM_BeltTimeCount();
                    beltCount.c_beltname = beltNo;
                    beltCount.c_beltno = beltNo;
                    string tagName = dic[beltNo].ToString();
                    beltCount.c_beltInfo = tagName;
                    int count = 0;
                    DateTime start = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    DateTime end = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    List<HisDataSet> hisDataList = getHisData(start, end, tagName);
                    if (hisDataList.Count > 0)
                    {
                        List<DateTime> timeList = new List<DateTime>();
                        //List<TimeSpan> timeSpanList = new List<TimeSpan>();
                        bool flag = true;
                        DateTime timeStamp1 = new DateTime();
                        DateTime timeStamp2 = new DateTime();

                        for (int i = hisDataList.Count - 1; i >= 0; i--)
                        {
                            HisDataSet hds = hisDataList[i];
                            if (hds.Count > 0)
                            {
                                for (int j = hds[0].Data.Count - 1; j >= 0; j--)
                                {
                                    try
                                    {
                                        if (hds[0].Data[j].Value != null && hds[0].Data[j].TimeStamp != null)
                                        {
                                            Double _value = Convert.ToDouble(hds[0].Data[j].Value.ToString());
                                            if (_value > 0.01 && flag == true)
                                            {
                                                timeStamp1 = hds[0].Data[j].TimeStamp;
                                                timeList.Add(timeStamp1);
                                                flag = false;
                                            }
                                            else if (_value <= 0.01 && flag == false)
                                            {
                                                timeStamp2 = hds[0].Data[j].TimeStamp;
                                                flag = true;
                                                timeList.Add(timeStamp2);
                                            }
                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        if (timeList.Count > 0)
                        {
                            if (timeList.Count % 2 == 1)
                            {
                                DateTime time = hisDataList[0][0].Data[0].TimeStamp;

                                timeList.Add(time);
                            }
                        }
                        //根据timeList计算出皮带秤时长
                        for (int i = 0; i < timeList.Count - 1; i += 2)
                        {
                            DateTime time1 = timeList[i];
                            DateTime time2 = timeList[i + 1];
                            TimeSpan span = time1 - time2;
                            count += Convert.ToInt32(span.TotalSeconds);
                        }

                    }
                    beltCount.c_beltTimeTotalCount = count.ToString();
                    list.Add(beltCount);

                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (string key in dic.Keys)
                {
                    PM_BeltTimeCount beltCount = new PM_BeltTimeCount();
                    beltCount.c_beltname = key;
                    beltCount.c_beltno = key;
                    string tagName = dic[key].ToString();
                    beltCount.c_beltInfo = tagName;
                    int count = 0;
                    DateTime start = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    DateTime end = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-us"));
                    List<HisDataSet> hisDataList = getHisData(start, end, tagName);

                    if (hisDataList.Count > 0)
                    {
                        List<DateTime> timeList = new List<DateTime>();
                        //List<TimeSpan> timeSpanList = new List<TimeSpan>();
                        bool flag = true;
                        DateTime timeStamp1 = new DateTime();
                        DateTime timeStamp2 = new DateTime();

                        for (int i = hisDataList.Count - 1; i >= 0; i--)
                        {
                            HisDataSet hds = hisDataList[i];
                            if (hds.Count > 0)
                            {
                                for (int j = hds[0].Data.Count - 1; j >= 0; j--)
                                {
                                    try
                                    {
                                        if (hds[0].Data[j].Value != null && hds[0].Data[j].TimeStamp != null)
                                        {
                                            Double _value = Convert.ToDouble(hds[0].Data[j].Value.ToString());
                                            if (_value > 0.01 && flag == true)
                                            {
                                                timeStamp1 = hds[0].Data[j].TimeStamp;
                                                timeList.Add(timeStamp1);
                                                flag = false;
                                            }
                                            else if (_value <= 0.01 && flag == false)
                                            {
                                                timeStamp2 = hds[0].Data[j].TimeStamp;
                                                flag = true;
                                                timeList.Add(timeStamp2);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        if (timeList.Count > 0)
                        {
                            if (timeList.Count % 2 == 1)
                            {
                                DateTime time = hisDataList[0][0].Data[0].TimeStamp;

                                timeList.Add(time);
                            }
                        }
                        //根据timeList计算出皮带秤时长
                        for (int i = 0; i < timeList.Count - 1; i += 2)
                        {
                            DateTime time1 = timeList[i];
                            DateTime time2 = timeList[i + 1];
                            TimeSpan span = time1 - time2;
                            count += Convert.ToInt32(span.TotalSeconds);
                        }
                    }
                    beltCount.c_beltTimeTotalCount = count.ToString();
                    list.Add(beltCount);
                }
            }
            return list;
        }

        public List<HisDataSet> getHisData(DateTime startTime, DateTime endTime, string tagName)
        {
            Login();

            List<HisDataSet> hisdatalist = new List<HisDataSet>();

            if (dbconnector.IsConnected())
            {

                //HisDataSet hisdataset = null;

                TagTree tagTree = TagTree.CreateInstance(dbconnector);
                TagNode tagNode = new TagNode();
                tagNode = tagTree.GetTreeRoot();

                TagVector tag = new TagVector();
                tag = tagNode.SelectNodes("[Name=" + tagName + "]@His_isSave");

                if (endTime > System.DateTime.Now)
                {
                    //查询时间不能超过当前时间，否则为空而出错
                    endTime = System.DateTime.Now;
                }

                while (startTime < endTime)
                {
                    //获取历史时间
                    HisDataSet hisdataset = new HisDataSet();
                    //TimeSpan ts = new TimeSpan(0, 0, 1);

                    if (startTime.AddHours(1) > endTime)
                    {
                        //查询方法一
                        BatchResults rslt = DataIO.ReadRaw(dbconnector, tag, startTime, endTime, hisdataset, 10000, true);

                        //查询方法二
                        //BatchResults rslt = DataIO.ReadProcessed(dbConnector, tag, startTime, endTime, ts, AggregateEnum.INTERPOLATIVE, hisdataset);
                        hisdatalist.Add(hisdataset);

                        startTime = endTime;
                    }
                    else
                    {
                        try
                        {
                            BatchResults rslt = DataIO.ReadRaw(dbconnector, tag, startTime, startTime.AddHours(1), hisdataset, 10000, true);

                            //BatchResults rslt = DataIO.ReadProcessed(dbConnector, tag, startTime, endTime, ts, AggregateEnum.INTERPOLATIVE, hisdataset);
                            hisdatalist.Add(hisdataset);

                            //将开始时间改为上次的结束时间
                            //startTime = hisdataset[0].Data[hisdataset[0].Data.Count - 1].TimeStamp.AddSeconds(1);
                            startTime = startTime.AddHours(1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

            Dispose();
            return hisdatalist;

        }

    }
}
