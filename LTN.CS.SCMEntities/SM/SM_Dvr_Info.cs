using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.Core;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_Dvr_Info : BaseEntity
    {

        public int IntId { get; set; } //业务主键
        public SM_PoundSite_Info PoundId { get; set; } //磅点ID 
        public string DvrFactory { get; set; } //硬盘录像机厂商
        public string DvrSpec { get; set; } //硬盘录像机规格
        public string DvrModel { get; set; } //硬盘录像机型号
        public string DvrIP1 { get; set; }  //硬盘录像机IP地址
        public string DvrIP2 { get; set; }  //硬盘录像机Id地址
        public int ChannelNub { get; set; } //通道数
        public int Storage { get; set; }  //存储空间大小
        public string Username { get; set; } //用户
        public string Password { get; set; } //密码
        public string Port { get; set; } //端口号
        //public DataTypeObj IsCancle { get; set; } //是否作废
        public string createUser { get; set; } //新增人员
        public string updateUser { get; set; }  //修改人员UpdateUser                                              
        public string createTime { get; set; } //新增时间
        public string updateTime { get; set; }  //修改时间

    }
}
