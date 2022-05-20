using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Base.Interface
{
    public interface IBaseBusiness
    {
        /// <summary>
        /// 检查原始数据是否满足过磅规则条件 intId 为委托单ID
        /// </summary>
        /// <param name="intId"></param>
        bool CheckRawData(int intId, out string msg);
        /// <summary>
        /// 利用满足条件的原始数据计算生成磅单 intId 为委托单ID
        /// </summary>
        /// <param name="intId"></param>
        void OperationRawData(int intId);
        /// <summary>
        /// 返回当前过磅重量类型
        /// </summary>
        /// <param name="intId"></param>
        int ReturnWeightType(int intId);
    }
}
