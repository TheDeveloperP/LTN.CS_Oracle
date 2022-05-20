using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Helper
{
    public class DeliveryInt
    {
        public int DeliveryValue { get; set; }
        public DeliveryInt() { }
        public DeliveryInt(int deliveryValue) { DeliveryValue = deliveryValue; }
        public string DeliveryDes
        {
            get
            {
                string rs = string.Empty;
                switch (DeliveryValue)
                {
                    case 1:
                        rs = "待审核";
                        break;
                    case 2:
                        rs = "已核准";
                        break;
                    case 3:
                        rs = "已退回";
                        break;
                }
                return rs;
            }
        }
    }
}
