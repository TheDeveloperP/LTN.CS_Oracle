// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMEntities.Common
// Author:kolio
// Created:2016/7/4 16:30:20
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/7/4 16:30:20
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LTN.CS.Base.Common
{
    [DataContract]
    public class UploadStatusObj
    {
        public UploadStatusObj() { }
        public UploadStatusObj(int statusInt)
        {
            IntValue = statusInt;
        }
        [DataMember]
        public int IntValue { get; set; }
        public UploadStatus EnumValue
        {
            get
            {
                UploadStatus rs = UploadStatus.Uploaded;
                try
                {
                    rs = (UploadStatus)IntValue;
                }
                catch (Exception)
                {

                }
                return rs;
            }
        }

        public static IList<UploadStatusObj> GetUploadStatusData()
        {
            IList<UploadStatusObj> rss = new List<UploadStatusObj>();
            try
            {
                foreach (int s in Enum.GetValues(typeof(UploadStatus)))
                {
                    rss.Add(new UploadStatusObj(s));
                }
            }
            catch (Exception)
            {

            }
            return rss;
        }

        public string UploadStatusDesc
        {
            get
            {
                string rs = string.Empty;
                try
                {
                    string EnumName = Enum.GetName(typeof(UploadStatus), IntValue);
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
