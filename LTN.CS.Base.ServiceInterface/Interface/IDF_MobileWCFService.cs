using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using LTN.CS.Base.ServiceInterface.Entity;
using LTN.CS.Base.ServiceInterface.Gam;
using System.IO;

namespace LTN.CS.Base.ServiceInterface.Interface
{
    [ServiceContract(Namespace = "Spring.WCF")]
    public interface IDF_MobileWCFService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MeasurePlans", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string MeasurePlans(Stream info);

        [OperationContract]
        [WebInvoke(UriTemplate = "TestFun", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        string TestFun(Stream pstream);
    }
}
