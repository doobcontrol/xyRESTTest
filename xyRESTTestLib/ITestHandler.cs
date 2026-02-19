using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyRESTTestLib
{
    public interface ITestHandler
    {
        Dictionary<string, string>? ParseHeaders(
            Dictionary<string, object> HeadersData,
            Dictionary<string, string> contextPars);
        HttpContent? ParseRequestBody(
            ContentInfo? contentInfo,
            Dictionary<string, string> contextPars);
        Task<bool> AssertResponse(
            HttpResponseMessage response,
            AssertInfo assertInfo,
            Dictionary<string, string> contextPars,
            StreamWriter rw);

        List<Dictionary<string, string>> GenerateTestDatas(
            DataGenerator dataGenerator);
        TestTask ApplyLocalPars(TestTask task, Dictionary<string, string> LocalPars);
    }
}
