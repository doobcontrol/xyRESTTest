using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
            bool ret = true;
            switch(assertInfo.assertType)
            {
                case "StatusCode":
                    int expectedCode = int.Parse(assertInfo.expected);
                    if ((int)response.StatusCode != expectedCode)
                    {
                        rw.WriteLine(
                            $"Assert Failed: Expected status code " +
                            $"{expectedCode}, but got " +
                            $"{(int)response.StatusCode}");
                        return false;
                    }
                    break;
                case "JsonContent":
                    string responseBody = 
                        await response.Content.ReadAsStringAsync();

                    if(assertInfo.assertList != null)
                    {
                        var assertList = assertInfo.assertList;
                        //assert content type
                        if(response.Content.Headers.ContentType == null
                            || !response.Content.Headers.ContentType.MediaType
                                .Contains("application/json"))
                        {
                            rw.WriteLine($"Assert Failed: " +
                                $"Expected content type " +
                                $"application/json, but got " +
                                $"{response.Content.Headers.ContentType}");
                            return false;
                        }
                        foreach (var al in assertList)
                        {
                            string jsonPath = al.Key;
                            string expectedValue = al.Value;
                            // Here you would use a JSON parsing library to extract the value
                            // from the response body using the jsonPath and compare it to expectedValue.
                            // This is a placeholder for that logic.
                            JsonNode? node = new JsonTools(responseBody).GetNodeByPath(jsonPath);
                            if (node == null)
                            {
                                rw.WriteLine($"Assert Failed: JSON path '{jsonPath}' " +
                                    $"not found in response.");
                                ret = false;
                            }
                            else
                            {
                                if (node.GetValue<string>() != expectedValue)
                                {
                                    rw.WriteLine($"Assert Failed: Expected value at JSON path '" +
                                        $"{jsonPath}' to be '{expectedValue}', but got '" +
                                        $"{node.GetValue<string>()}'.");
                                    ret = false;
                                }
                            }
                        }
                    }
                    if (assertInfo.readList != null)
                    {
                        var readList = assertInfo.readList;
                        foreach (var rl in readList)
                        {
                            string varName = rl.Key;
                            string jsonPath = rl.Value;
                            // Here you would use a JSON parsing library to extract the value
                            // from the response body using the jsonPath and store it in contextPars
                            // for use in later tests. This is a placeholder for that logic.

                            JsonNode? node = new JsonTools(responseBody).GetNodeByPath(jsonPath);
                            if (node == null)
                            {
                                rw.WriteLine($"Assert Failed: JSON path '{jsonPath}' not found in response.");
                                ret = false;
                            }
                            else
                            {
                                contextPars[varName] = node.GetValue<string>();
                            }
                        }
                    }
                    break;
                default:
                    rw.WriteLine($"Assert Failed: Unknown assert type " +
                        $"'{assertInfo.assertType}'.");
                    return false;
            }
            return ret;
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

        public HttpContent? ParseRequestBody(
            ContentInfo? contentInfo, 
            Dictionary<string, string> contextPars)
        {
            if(contentInfo == null) { 
                return null;
            }
            HttpContent? bodyContent = null;
            switch(contentInfo.type)
            {
                case "SimpleJson":
                    var bodyString = RcontentTools.SimpleJson(
                        contentInfo.recordData);
                    if (bodyString != null)
                    {
                        bodyContent = new StringContent(
                            bodyString, 
                            Encoding.GetEncoding(contentInfo.encoding), 
                            contentInfo.ctype
                            );
                    }
                    break;
                default:
                    break;
            }
            return bodyContent;
        }
    }
}
