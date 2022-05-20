using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.Enum
{
    /// <summary>
    /// 业务类型
    /// </summary>
    public enum BUSINESSTYPE
    {
        进厂 = 0,
        出厂 = 1,
        内倒 = 2,
        //铁路集装箱转运 = 3
        //2022-5-9 新增4种业务类型  潘鹏
        火车进厂 = 3,
        采购内转 = 4,
        内倒_外 = 7,
        火车集装箱 = 8
    }


    /// <summary>
    /// 委托类型
    /// </summary>
    public enum PLANTYPE
    {
        长期委托 = 0,
        一次委托 = 1
    }


    /// <summary>
    /// 过磅方式
    /// </summary>
    public enum WEIGHTTYPE
    {
        先皮后毛 = 1,
        先毛后皮 = 2,
        限期皮重 = 3
    }

    /// <summary>
    /// 一车多货
    /// </summary>
    public enum ONEMORESTOCK
    {
        无 = 0,
        一车多装 = 1,
        一车多卸 = 2
    }


    /// <summary>
    /// 母子标识
    /// </summary>
    public enum ISCHILDIDENFY
    {
        正常=0,
        子标识 = 1,
        母标识 = 2
    }

    /// <summary>
    /// 偏差方式
    /// </summary>
    public enum COMPUTERTYPE
    {
        无 = 0,
        固定值 = 1,
        百分比 = 2
    }


    /// <summary>
    /// 复磅标志
    /// </summary>
    public enum REPEATPOUND
    {
        无 = 0,
        毛毛皮 = 1,
        毛毛皮皮 = 2
    }

    /// <summary>
    /// 计量状态
    /// </summary>
    public enum PLANSTATE
    {
        未完成 = 0,
        已完成 = 1,
        已作废 = 2,
    }

}
