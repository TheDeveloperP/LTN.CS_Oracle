// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Base.ServiceInterface.Interface
// Author:kolio
// Created:2016/8/9 13:54:31
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/8/9 13:54:31
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using LTN.CS.Base.ServiceInterface.Entity;

namespace LTN.CS.Base.ServiceInterface.Interface
{
    [ServiceContract(Namespace = "Spring.WCF")]
    public interface IDM_TaskWCFService
    {
        /// <summary>
        /// 新增任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int CreateTask(DM_Task_WCF task, out int taskId, out string errorMsg);
        /// <summary>
        /// 坐席接受任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int ReciveTask(int taskId, int siteId, int pondId, out string errorMsg,bool isKeep = false);
        /// <summary>
        /// 坐席不接受任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int UnReciveTask(int taskId, int siteId, int pondId, out string errorMsg, bool isKeep = false);
        /// <summary>
        /// 任务结束
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int DeleteTaskRoute(int taskId, int siteId, int pondId, out string errorMsg, bool isFromSite = false, string data="");
        /// <summary>
        /// 查询所有路由关系
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [OperationContract]
        IList<DM_Route_Query_WCF> QueryAllRoute(out string errorMsg);

        /// <summary>
        /// 查询所有任务
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [OperationContract]
        IList<DM_Task_WCF> QueryAllTask(out string errorMsg);

        /// <summary>
        /// 打开坐席时初始化坐席状态
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        [OperationContract]
        int InitSiteForLoad(int siteId, out string errorMsg);
    }
}
