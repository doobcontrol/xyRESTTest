using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyRESTTestLib;

namespace xyRESTTest
{
    internal class TestHandler : ITestHandler
    {
        public async Task<bool> AssertResponse(
            HttpResponseMessage response,
            AssertInfo assertInfo,
            Dictionary<string, string> contextPars, 
            StreamWriter rw)
        {
            switch(assertInfo.assertType)
            {
                case "StatusCode":
                    int expectedCode = (int)assertInfo.expected;
                    if ((int)response.StatusCode != expectedCode)
                    {
                        rw.WriteLine(
                            $"Assert Failed: Expected status code " +
                            $"{expectedCode}, but got " +
                            $"{(int)response.StatusCode}");
                        return false;
                    }
                    break;
                case "HeaderExists":
                    string headerName = assertInfo.expected as string;
                    if (!response.Headers.Contains(headerName))
                    {
                        rw.WriteLine($"Assert Failed: " +
                            $"Expected header '{headerName}' " +
                            $"not found in response.");
                        return false;
                    }
                    break;
                case "BodyContains":
                    string expectedContent = assertInfo.expected as string;
                    string responseBody = 
                        await response.Content.ReadAsStringAsync();
                    if (!responseBody.Contains(expectedContent))
                    {
                        rw.WriteLine($"Assert Failed: Expected response body to contain '{expectedContent}', but it was not found.");
                        return false;
                    }
                    //read data for potential use in later tests
                    if(assertInfo.readData != null)
                    {
                        var readDataList =
                        assertInfo.readData as Dictionary<string, object>;
                        foreach (var rd in readDataList)
                        {
                            string varName = rd.Key;
                            string jsonPath = rd.Value as string;
                            // Here you would use a JSON parsing library to extract the value
                            // from the response body using the jsonPath and store it in contextPars
                            // for use in later tests. This is a placeholder for that logic.
                            string extractedValue =
                                new JsonTools(responseBody).GetValueByPath(jsonPath);
                            contextPars[varName] = extractedValue;
                        }
                    }
                    break;
                default:
                    rw.WriteLine($"Assert Failed: Unknown assert type " +
                        $"'{assertInfo.assertType}'.");
                    return false;
            }
            return true;
        }

        public Dictionary<string, string>? ParseHeaders(
            Dictionary<string, object> HeadersData, 
            Dictionary<string, string> contextPars)
        {
            if (HeadersData == null) { 
                return null; 
            }

            var headers = new Dictionary<string, string>();
            foreach (var hd in HeadersData)
            {
                switch(hd.Key)
                {
                    case "Authorization":
                        var authData= (AuthHeaderInfo)hd.Value;
                        if(authData.scheme == "Bearer")
                        {
                            // Get token value from context parameters if it
                            // contains the placeholder
                            string parName = "AuthToken";
                            string? token = contextPars.ContainsKey(parName)
                                ? contextPars[parName] : null;
                            if (token != null
                                && authData.authToken.
                                Contains("${" + parName + "}"))
                            {
                                authData.authToken = authData.authToken.Replace(
                                    "${" + parName + "}",
                                    token);
                            }
                        }
                        string? headerValue = RheaderTools.HeaderAuth(authData);
                        if (headerValue != null)
                        {
                            headers["Authorization"] = headerValue;
                        }
                        break;
                    default:
                        break;
                }
            }

            return headers;
        }

        public string? ParseRequestBody(
            ContentInfo? contentInfo, 
            Dictionary<string, string> contextPars)
        {
            if(contentInfo == null) { 
                return null;
            }
            string? bodyString = null;
            switch(contentInfo.Value.type)
            {
                case "SimpleJson":
                    bodyString = RcontentTools.SimpleJson(
                        contentInfo.Value.recordData);
                    break;
                default:
                    break;
            }
            return bodyString;
        }
    }
}
