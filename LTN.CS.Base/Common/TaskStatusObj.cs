// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.Common
// Author:kolio
// Created:2016/8/5 9:53:43
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/5 9:53:43
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class TaskStatusObj
    {
        [DataMember]
        public int IntValue { get; set; }
        public TaskStatusObj() { }
        public TaskStatusObj(int taskStatusInt)
        {
            IntValue = taskStatusInt;
        }
        public TaskStatus EnumValue
        {
            get
            {
                TaskStatus rs = TaskStatus.Accepting;
                try
                {
                    rs = (TaskStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
        public static IList<TaskStatusObj> GetTaskStatusData()
        {
            IList<TaskStatusObj> rss = new List<TaskStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(TaskStatus)))
                {
                    rss.Add(new TaskStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }
        public string TaskStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(TaskStatus), IntValue);
                    rs = EnumName;
                    rs = LTN.CS.Base.Properties.Resources.ResourceManager.GetString(EnumName);
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }
    }
}
