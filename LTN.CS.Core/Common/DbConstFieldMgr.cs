using System;
using System.Collections.Generic;
using System.Linq;

namespace LTN.CS.Core.Common
{
    public static class DbConstFieldMgr
    {
        /// <summary>
        /// 数据表主键字段名
        /// </summary>
        public static string IdField { get { return "IntId"; } }
        /// <summary>
        /// 数据表启禁用字段名
        /// </summary>
        public static string IntActiveField { get { return "IntActive"; } }

        /// <summary>
        /// 数据表中排序字段名
        /// </summary>
        public static string IntSeqField { get { return "IntSeq"; } }

        /// <summary>
        /// 数据表中逻辑删除、作废字段名
        /// </summary>
        public static string IntIsDeleteField { get { return "IntIsDelete"; } }

        /// <summary>
        /// 数据表中更新人员Id的字段名
        /// </summary>
        public static string CreateUserIdField { get { return "CreateUserId"; } }

        /// <summary>
        ///  数据表中创建时间的字段名
        /// </summary>
        public static string CreateDateTimeField { get { return "CreateDateTime"; } }

        /// <summary>
        /// 数据表中创建时间的字段名
        /// </summary>
        public static string UpdateUserIdField { get { return "UpdateUserId"; } }

        /// <summary>
        /// 数据表中更新时间的字段名
        /// </summary>
        public static string UpdateDateTimeField { get { return "UpdateDateTime"; } }

        /// <summary>
        /// 存储过程中需要传入的返回值栏位名
        /// </summary>
        public static string Return_ValueField { get { return "RETURN_VALUE"; } }

        /// <summary>
        /// 调用存储过程时传入的参数,1:新增,2:修改,3:删除,4:逻辑删除,5:更新启禁用状态
        /// </summary>
        public static string flagField { get { return "flag"; } }

        /// <summary>
        /// 存储过程中执行返回的生成Id的栏位名
        /// </summary>
        public static string newIdField { get { return "newId"; } }

        /// <summary>
        /// 存储过程中执行返回的消息栏位名
        /// </summary>
        public static string msgField { get { return "msg"; } }


        #region 其他常量字段配置

        /// <summary>
        /// 返回数据库使用ADO.NET时的前导参数字符串,默认为:'@'
        /// </summary>
        public static char prefixParmSign { get { return '@'; } }


        #endregion


        #region 登录用户相关信息封装

        /// <summary>
        /// 用户操作资料中用户Id
        /// </summary>
        public static string IntUserId { get { return "userID"; } }


        /// <summary>
        /// 用户操作资料中用户名称
        /// </summary>
        public static string StrUserName { get { return "userName"; } }


        /// <summary>
        /// 用户操作资料中用户所属组别Id
        /// </summary>
        public static string IntGroupId { get { return "groupID"; } }


        /// <summary>
        /// 用户操作资料中用户所属组别名称
        /// </summary>
        public static string StrGroupName { get { return "groupName"; } }


        /// <summary>
        /// 用户操作资料中用户所属组别名称
        /// </summary>
        public static string IntSafeTime { get { return "safeTime"; } }

        #endregion
    }
}
