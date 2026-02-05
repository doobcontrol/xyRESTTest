using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyRESTTest
{
    internal class tools
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static HttpRequestMessage makeHttpRequestMessage(
            string url,
            HttpMethod method,
            Dictionary<string, string>? headers = null,
            HttpContent? content = null
            )
        {
            var rMsg = new HttpRequestMessage();
            rMsg.RequestUri = new Uri(url);
            rMsg.Method = method;
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    rMsg.Headers.Add(header.Key, header.Value);
                }
            }
            if (content != null 
                && (method == HttpMethod.Post || method == HttpMethod.Put))
            {
                rMsg.Content = content;
            }

            return rMsg;
        }
    }
}
