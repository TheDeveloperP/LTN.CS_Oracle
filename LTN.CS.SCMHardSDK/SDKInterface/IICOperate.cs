using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTN.CS.SCMHardSDK.SDKInterface
{
    public interface IICOperate
    {
        bool ICInit(int comno = 0);
        string ICRead(int comno);
        void ICExit();
        void ICBeep(int time);
    }
}
