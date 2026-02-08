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
            object HeadersData, 
            Dictionary<string, string> contextPars)
        {
            var headerList =
                HeadersData as Dictionary<string, object>;
            if (headerList == null) { 
                return null; 
            }

            var headers = new Dictionary<string, string>();
            foreach (var hd in headerList)
            {
                switch(hd.Key)
                {
                    case "Authorization":
                        var authData=
                            ((string scheme, object parameter))hd.Value;
                        switch (authData.scheme)
                        {
                            case "Basic":
                                List<string> basicPars = (List<string>)authData.parameter;
                                if (basicPars.Count == 2)
                                {
                                    var hString = "Basic " +
                                        xyTest.Base64Encode(
                                            $"{basicPars[0]}:{basicPars[1]}"
                                        );
                                    headers["Authorization"] = hString;
                                }
                                break;
                            case "Bearer":
                                // This is a convention for the parameter name in contextPars,
                                // you can change it as needed.
                                string parName = "AuthToken"; 
                                string token = contextPars.ContainsKey(parName) 
                                    ? contextPars[parName] : null;
                                string parValue = (string)authData.parameter;
                                if (token != null 
                                    && parValue.Contains("${" + parName + "}"))
                                {
                                    parValue = parValue.Replace(
                                        "${" + parName + "}", 
                                        token);
                                }
                                headers["Authorization"] = "Bearer " + parValue;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            return headers;
        }

        public string? ParseRequestBody(
            object BodyData, 
            Dictionary<string, string> contextPars)
        {
            string? bodyString = null;
            (string bodyType, object bodyData) bodyInfo 
                = ((string, object))BodyData;
            switch(bodyInfo.bodyType)
            {
                case "raw":
                    bodyString = bodyInfo.bodyData as string;
                    break;
                case "jsonOneUser":
                    List<string> userData = bodyInfo.bodyData as List<string>;
                    bodyString = $"{{\"FID\":\"{userData[0]}\", "
                        + $"\"FUserName\":\"{userData[1]}\", "
                        + $"\"FPassword\":\"{userData[2]}\"}}";
                    break;
                default:
                    break;
            }
            return bodyString;
        }
    }
}
