using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Helper
{
    public static partial class DictionaryConfiguiation
    {
        /// <summary>
        /// 条码临时表关键字
        /// </summary>
        public static string CodeTempKey { get { return ConfigHelper.GetDictonaryConfigSn("CodeTempKey"); } }
        /// <summary>
        /// 银行名称
        /// </summary>
        public static string DicBankName { get { return ConfigHelper.GetDictonaryConfigSn("DicBankName"); } }

        /// <summary>
        /// 商家类型
        /// </summary>
        public static string DicBusinessType { get { return ConfigHelper.GetDictonaryConfigSn("DicBusinessType"); } }

        /// <summary>
        /// 大计量单位
        /// </summary>
        public static string DicMaterialLargeUnit { get { return ConfigHelper.GetDictonaryConfigSn("DicMaterialLargeUnit"); } }

        /// <summary>
        /// 小计量单位
        /// </summary>
        public static string DicMaterialSmallUnit { get { return ConfigHelper.GetDictonaryConfigSn("DicMaterialSmallUnit"); } }

        /// <summary>
        /// 用途
        /// </summary>
        public static string DicPurpose { get { return ConfigHelper.GetDictonaryConfigSn("DicPurpose"); } }

        /// <summary>
        /// 计划状态
        /// </summary>
        public static string DicPlanStatus { get { return ConfigHelper.GetDictonaryConfigSn("DicPlanStatus"); } }

        /// <summary>
        /// 计划执行状态
        /// </summary>
        public static string DicPlanExecuteStatus { get { return ConfigHelper.GetDictonaryConfigSn("DicPlanExecuteStatus"); } }

        /// <summary>
        /// 调整单类型
        /// </summary>
        public static string DicAdjustType { get { return ConfigHelper.GetDictonaryConfigSn("DicAdjustType"); } }
        /// <summary>
        /// 磅点类型
        /// </summary>
        public static string DicSiteType { get { return ConfigHelper.GetDictonaryConfigSn("DicSiteType"); } }

        /// <summary>
        /// 业务类型
        /// </summary>
        public static string DicBillType { get { return ConfigHelper.GetDictonaryConfigSn("DicBillType"); } }

        /// <summary>
        /// 贸易关系
        /// </summary>
        public static string DicTradeRelation { get { return ConfigHelper.GetDictonaryConfigSn("DicTradeRelation"); } }
        /// <summary>
        /// 所属主体
        /// </summary>
        public static string DicSubject { get { return ConfigHelper.GetDictonaryConfigSn("DicSubject"); } }
        //坐席类别
        public static string SeatType { get { return ConfigHelper.GetDictonaryConfigSn("SeatType"); } }

        //仪表类别
        public static string MeterType { get { return ConfigHelper.GetDictonaryConfigSn("MeterType"); } }
        //皮重采用方式
        public static string DicTareType { get { return ConfigHelper.GetDictonaryConfigSn("DicTareType"); } }

        //业务类型标识
        public static string DicBusinessTypeDesc { get { return ConfigHelper.GetDictonaryConfigSn("DicBusinessTypeDesc"); } }

        //IC卡状态
        public static string ICState { get { return ConfigHelper.GetDictonaryConfigSn("DicSourceDesc"); } }

        //IC卡发行状态
        public static string IssuingState { get { return ConfigHelper.GetDictonaryConfigSn("DicBusinessTypeDesc"); } }

        //皮带秤类别
        public static string DicPdcClass { get { return ConfigHelper.GetDictonaryConfigSn("DicPdcClass"); } }

        //皮带秤区域
        public static string DicPdcArea { get { return ConfigHelper.GetDictonaryConfigSn("DicPdcArea"); } }

        //行业名称
        public static string DicIndustry { get { return ConfigHelper.GetDictonaryConfigSn("DicIndustry"); } }

        //过磅模式，自动/手动
        public static string WgtMode { get { return ConfigHelper.GetDictonaryConfigSn("WgtMode"); } }
        //过磅模式，单捆/双捆
        public static string WgtNum { get { return ConfigHelper.GetDictonaryConfigSn("WgtNum"); } }
        //质量信息
        public static string QualityInfo { get { return ConfigHelper.GetDictonaryConfigSn("QualityInfo"); } }
        //尺寸信息
        public static string FlagInfo { get { return ConfigHelper.GetDictonaryConfigSn("FlagInfo"); } }
        //是否压地
        public static string WgtType { get { return ConfigHelper.GetDictonaryConfigSn("WgtType"); } }
        //重量回落点
        public static string WgtArea { get { return ConfigHelper.GetDictonaryConfigSn("WgtArea"); } }
        //过磅模式，自动/手动
        public static string LoadCrew { get { return ConfigHelper.GetDictonaryConfigSn("LoadCrew"); } }

        /// <summary>
        /// 成品秤理重计算
        /// </summary>
        public static string CalcWeight { get { return ConfigHelper.GetDictonaryConfigSn("CalcWeight"); } }

        public static string CountMode { get { return ConfigHelper.GetDictonaryConfigSn("CountMode"); } }

        /// <summary>
        /// 圆钢波动范围
        /// </summary>
        public static string RangeValue { get { return ConfigHelper.GetDictonaryConfigSn("RangeValue"); } }
        /// <summary>
        /// 重量稳定循环次数
        /// </summary>
        public static string SaveTime { get { return ConfigHelper.GetDictonaryConfigSn("SaveTime"); } }
        public static string WeightSite { get { return ConfigHelper.GetDictonaryConfigSn("WeightSite"); } }
    }
}
