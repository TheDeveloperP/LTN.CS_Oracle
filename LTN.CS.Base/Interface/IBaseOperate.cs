using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Interface
{
    public interface IBaseOperate
    {
        /// <summary>
        /// 接收任务（坐席端为接收到任务调度分派的任务，磅房端为任务调度通知磅房坐席已经接收该任务）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void ReciveNewTask(string data, int taskId,int pondId,int siteId,string taskNo);
        /// <summary>
        /// 打印磅单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void PrintPondBill(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 更新提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void ShowMsg(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 任务结束
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void TaskEnd(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 声光报警
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void Warning(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 断电
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void PowerOut(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 清零
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void ClearZero(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 其他操作（备用）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void OtherOperate(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 任务中断
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void TaskBreak(string data, int taskId, int pondId, int siteId, string taskNo);

        /// <summary>
        /// 来车提醒
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void TrackComing(string data, int taskId, int pondId, int siteId, string taskNo);

        /// <summary>
        /// 车组结束
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void TrackEnd(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 车皮重量信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="taskNo"></param>
        void TrackWeight(string data, int taskId, int pondId, int siteId, string taskNo);
        /// <summary>
        /// 磅房发给坐席中断任务指令
        /// </summary>
        /// <param name="data"></param>
        /// <param name="taskId"></param>
        /// <param name="pondId"></param>
        /// <param name="siteId"></param>
        /// <param name="taskNo"></param>
        void PondToSiteEndTask(string data, int taskId, int pondId, int siteId, string taskNo);
    }
}
