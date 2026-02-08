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
            Object HeadersData,
            Dictionary<string, string> contextPars);
        string? ParseRequestBody(
            Object BodyData,
            Dictionary<string, string> contextPars);
        Task<bool> AssertResponse(
            HttpResponseMessage response,
            AssertInfo assertInfo,
            Dictionary<string, string> contextPars,
            StreamWriter rw);
    }
}
