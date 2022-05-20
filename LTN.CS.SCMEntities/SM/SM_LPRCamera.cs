using LTN.CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.SM
{
    public class SM_LPRCamera: BaseEntity
    {
        public int IntId { get; set; }  //业务主键
        public string LPRFactory { get; set; }  //车牌识别摄像机厂商
        public string LPRSpec { get; set; } //车牌识别摄像机规格
        public string LPRModel { get; set; }    //车牌识别摄像机型号
        public string LPRIP1 { get; set; }  //车牌识别摄像机IP1
        public string LPRIP2 { get; set; }  //车牌识别摄像机IP2
        public int ChannelNum { get; set; } //通道数
        public int Storage { get; set; }  //存储空间大小
        public string Username { get; set; } //用户
        public string Password { get; set; } //密码
        public string Port { get; set; } //端口号
        public string createUser { get; set; } //新增人员
        public string updateUser { get; set; }  //修改人员UpdateUser                                              
        public string createTime { get; set; } //新增时间
        public string updateTime { get; set; }  //修改时间
    }
}
