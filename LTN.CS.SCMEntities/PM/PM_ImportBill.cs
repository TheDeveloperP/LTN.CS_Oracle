using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.SCMEntities.PM
{
    public class PM_ImportBill
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int I_Intid { get; set; }
        /// <summary>
        /// 磅单号
        /// </summary>
        public string C_PondNo { get; set; }
        /// <summary>
        /// 创建人导入人
        /// </summary>
        public string C_CreateUserName { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string C_UpdateUserName { get; set; }
        /// <summary>
        /// 导入批号
        /// </summary>
        public string C_ImBatchNum { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string C_CarNo { get; set; }
        /// <summary>
        /// 毛重时间
        /// </summary>
        public DateTime? C_GrossWgtTime { get; set; }
        /// <summary>
        /// 皮重时间
        /// </summary>
        public DateTime? C_TareWgtTime { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string C_MaterialName { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public decimal N_GrossWgt { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public decimal N_TareWgt { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal N_NetWgt { get; set; }
        /// <summary>
        /// 供货单位
        /// </summary>
        public string C_FromDeptName { get; set; }
        /// <summary>
        ///收货单位
        /// </summary>
        public string C_ToDeptName { get; set; }
        /// <summary>
        /// 司磅员
        /// </summary>
        public string C_NetWgtMan { get; set; }
        /// <summary>
        /// 毛重站点
        /// </summary>
        public string C_GrossWgtSite { get; set; }
        public int I_PrintNum { get; set; }//打印次数
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Remark { get; set; }
    }
}
