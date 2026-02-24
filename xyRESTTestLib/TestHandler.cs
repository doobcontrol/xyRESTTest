using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using xyRESTTestLib.Properties;

namespace xyRESTTestLib
{
    public class TestHandler : ITestHandler
    {
        public TestTask ApplyLocalPars(TestTask task, Dictionary<string, string> LocalPars)
        {
            var json = JsonSerializer.Serialize(task);
            json = xyTest.HandleCaseParams(LocalPars, json);
            var newTask = JsonSerializer.Deserialize<TestTask>(json);
            if (newTask.requestInfo != null && newTask.requestInfo.headers != null)
            {
                foreach (var header in newTask.requestInfo.headers)
                {
                    if (header.Key == "Authorization")
                    {
                        newTask.requestInfo.headers[header.Key] =
                            JsonSerializer.Deserialize<AuthHeaderInfo>(header.Value.ToString());
                    }
                }
            }
            return newTask;
        }

        public async Task<bool> AssertResponse(
            HttpResponseMessage response,
            AssertInfo assertInfo,
            Dictionary<string, string> contextPars,
            StreamWriter rw)
        {
            bool ret = true;
            switch (assertInfo.assertType)
            {
                case nameof(AssertType.StatusCode):
                    int expectedCode = int.Parse(assertInfo.expected);
                    if ((int)response.StatusCode != expectedCode)
                    {
                        rw.WriteLine(
                            string.Format(
                                Resources.strAssertFailedStatusCode,
                                expectedCode, (int)response.StatusCode)
                        );
                        return false;
                    }
                    break;
                case nameof(AssertType.JsonContent):
                    string responseBody =
                        await response.Content.ReadAsStringAsync();

                    if (assertInfo.assertList != null)
                    {
                        //assert content type
                        if (response.Content.Headers.ContentType == null
                            || !response.Content.Headers.ContentType.MediaType
                                .Contains(xyTest.CT_app_json))
                        {
                            rw.WriteLine(
                                string.Format(
                                    Resources.strAssertFailedNotJSON,
                                    response.Content.Headers.ContentType)
                            );
                            return false;
                        }
                        foreach (var al in assertInfo.assertList)
                        {
                            string jsonPath = al.Key;
                            string expectedValue = al.Value;
                            // Here you would use a JSON parsing library to extract the value
                            // from the response body using the jsonPath and compare it to expectedValue.
                            // This is a placeholder for that logic.
                            JsonNode? node = new JsonTools(responseBody).GetNodeByPath(jsonPath);
                            if (node == null)
                            {
                                rw.WriteLine(
                                    string.Format(
                                        Resources.strAssertFailedJSONPathNotFound,
                                        jsonPath)
                                );
                                ret = false;
                            }
                            else
                            {
                                if (node.GetValue<string>() != expectedValue)
                                    {
                                    rw.WriteLine(
                                        string.Format(
                                            Resources.strAssertFailedStatusCode,
                                            jsonPath, expectedValue, node.GetValue<string>())
                                    );
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
                                rw.WriteLine(
                                    string.Format(
                                        Resources.strAssertFailedJSONPathNotFound,
                                        jsonPath)
                                );
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
                    rw.WriteLine(
                        string.Format(
                            Resources.strAssertFailedUnknowType,
                            assertInfo.assertType)
                    );
                    return false;
            }
            return ret;
        }

        public List<Dictionary<string, string>> GenerateTestDatas(DataGenerator dataGenerator)
        {
            var retList = new List<Dictionary<string, string>>();

            switch (dataGenerator.GeneratorType)
            {
                case nameof(GeneratorType.Basic):
                    if (dataGenerator.GeneratorInfo.TryGetValue(
                        xyTest.DGT_Basic_File, out string? filePath))
                    {
                        if (filePath != null)
                        {
                            var lines = File.ReadAllLines(filePath);
                            var headers = lines[0].Split(',');
                            for (int i = 1; i < lines.Length; i++)
                            {
                                var values = lines[i].Split(',');
                                var dataDict = new Dictionary<string, string>();
                                for (int j = 0; j < headers.Length; j++)
                                {
                                    dataDict[headers[j]] = values[j];
                                }
                                retList.Add(dataDict);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return retList;
        }

        public Dictionary<string, string>? ParseHeaders(
            Dictionary<string, object> HeadersData,
            Dictionary<string, string> contextPars)
        {
            if (HeadersData == null)
            {
                return null;
            }

            var headers = new Dictionary<string, string>();
            foreach (var hd in HeadersData)
            {
                switch (hd.Key)
                {
                    case nameof(HeaderType.Authorization):
                        var authData = (AuthHeaderInfo)hd.Value;
                        string? headerValue = RheaderTools.HeaderAuth(
                            authData, contextPars);
                        if (headerValue != null)
                        {
                            headers[hd.Key] = headerValue;
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
            if (contentInfo == null)
            {
                return null;
            }
            HttpContent? bodyContent = null;
            switch (contentInfo.type)
            {
                case nameof(JCType.SimpleJson):
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
