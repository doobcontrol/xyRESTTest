using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace xyRESTTestLib
{
    public class JsonTools
    {
        private JsonNode topNode;
        public JsonTools(string jsonString)
        {
            topNode = JsonNode.Parse(jsonString) ?? new JsonObject();
        }
        public string? GetValueByPath(string nodePath)
        {
            JsonNode? node = GetNodeByPath(nodePath);
            if (node == null) {
                return null;
            }
            return node.GetValue<string>();
        }
        public JsonNode? GetNodeByPath(string nodePath)
        {
            var pathParts = nodePath.Split('.');
            JsonNode tempNode = topNode;
            foreach (var part in pathParts)
            {
                if (part.Contains('[') && part.Contains(']'))
                {
                    // Array access
                    var indexStr = part.Substring(part.IndexOf('[') + 1,
                        part.IndexOf(']') - part.IndexOf('[') - 1);
                    if (int.TryParse(indexStr, out int index))
                    {
                        if (tempNode == null || tempNode[index] == null)
                        {
                            return null;
                        }
                        else
                        {
                            tempNode = tempNode[index];
                        }
                    }
                    else
                    {
                        // Invalid index
                        return null;
                    }
                }
                else
                {
                    if (tempNode == null || tempNode[part] == null)
                    {
                        return null;
                    }
                    else
                    {
                        tempNode = tempNode[part];
                    }
                }
            }
            return tempNode;
        }

    }
}
