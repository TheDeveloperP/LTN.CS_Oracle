using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace LTN.CS.Base.ServiceInterface.Interface
{
    [ServiceContract]
    public interface IMoveTrackDataService
    {
        /// <summary>
        /// 来车提醒
        /// </summary>
        /// <param name="LesNo">LES磅房编号</param>
        /// <param name="direction">来车方向：1 左  2 右</param>
        /// <param name="comingTime">来车时间 yyyyMMdd HH:mm:ss yyyy</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <returns>0失败  1成功</returns>
        [OperationContract]
        int TrackComing(string LesNo, int direction, string comingTime, out string ErrorMsg);

        /// <summary>
        /// 称重数据
        /// </summary>
        /// <param name="LesNo">LES磅房编号</param>
        /// <param name="order">过磅顺序号</param>
        /// <param name="carriageNo">车皮号 如没有为空字符串</param>
        /// <param name="formationTag">整车组标识 如：第一节车的过皮时间</param>
        /// <param name="weightData">称重数据 单位为T 小数点后面两位精度</param>
        /// <param name="speed">速度   数值加+单位 m/s</param>
        /// <param name="direction">来车方向：1 左  2 右</param>
        /// <param name="weightTime">过磅时间 yyyyMMdd HH:mm:ss yyyy</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <returns>0失败  1成功</returns>
        [OperationContract]
        int TrackWeightData(string LesNo, int order, string carriageNo, string formationTag, float weightData, string speed, int direction, string weightTime, out string ErrorMsg);

        /// <summary>
        /// 过磅结束
        /// </summary>
        /// <param name="LesNo">LES磅房编号</param>
        /// <param name="formationTag">整车组标识 如：第一节车的过皮时间</param>
        /// <param name="direction">来车方向：1 左  2 右</param>
        /// <param name="endTime">过磅截止时间 yyyyMMdd HH:mm:ss yyyy</param>
        /// <param name="dateNow">数据上传时间</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <returns>0失败  1成功</returns>
        [OperationContract]
        int TrackWeightEnd(string LesNo, string formationTag, int direction, string endTime, string dateNow, out string ErrorMsg);

        /// <summary>
        /// 零点信息
        /// </summary>
        /// <param name="LesNo">LES磅房编号</param>
        /// <param name="weightData">称重数据 单位为T 小数点后面两位精度</param>
        /// <param name="dateNow">数据上传时间 yyyyMMdd HH:mm:ss yyyy</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <returns>0失败  1成功</returns>
        [OperationContract]
        int TrackZeroPoint(string LesNo, float weightData, string dateNow, out string ErrorMsg);
    }
}
