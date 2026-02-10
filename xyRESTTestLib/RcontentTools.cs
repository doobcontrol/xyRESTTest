using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyRESTTestLib
{
    public class RcontentTools
    {
        public static string? SimpleJson(Dictionary<string, string> data)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            foreach(var kv in data)
            {
                sb.Append($"\"{kv.Key}\": \"{kv.Value}\",");
            }
            if (data.Count > 0)
            {
                sb.Length--; // Remove the trailing comma
            }
            sb.Append("}");
            return sb.ToString();
        }
    }

    public struct ContentInfo
    {
        public string type = "SimpleJson"; // e.g., "SimpleJson"
        public string ctype = "application/json"; // e.g., "application/json"
        public string encoding = "UTF-8"; // e.g., "UTF-8"
        public Dictionary<string, string>? recordData;

        public ContentInfo()
        {
        }
    }
}
