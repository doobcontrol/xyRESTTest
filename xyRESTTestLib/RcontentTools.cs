using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

    public class ContentInfo
    {
        public string type { get; set; } = "SimpleJson"; // e.g., "SimpleJson"
        public string ctype { get; set; } = "application/json"; // e.g., "application/json"
        public string encoding { get; set; } = "UTF-8"; // e.g., "UTF-8"
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? recordData { get; set; }
    }
}
