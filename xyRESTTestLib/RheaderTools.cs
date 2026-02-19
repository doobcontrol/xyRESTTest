using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyRESTTestLib
{
    public class RheaderTools
    {
        public static string? HeaderAuth(
            AuthHeaderInfo authHeaderInfo,
            Dictionary<string, string> parsDic)
        {
            string? header = null;
            switch (authHeaderInfo.scheme)
            {
                case "Basic":
                    header = HeaderAuthBasic(
                        xyTest.HandleContextParams(parsDic, authHeaderInfo.username),
                        xyTest.HandleContextParams(parsDic, authHeaderInfo.password));
                    break;
                case "Bearer":
                    header = HeaderAuthBearer(
                        xyTest.HandleContextParams(parsDic, authHeaderInfo.authToken));
                    break;
            }
            return header;
        }
        public static string? HeaderAuthBasic(
            string username, string password)
        {
            return "Basic " + xyTest.Base64Encode($"{username}:{password}"); ;
        }
        public static string? HeaderAuthBearer(
            string authToken)
        {
            return "Bearer " + authToken;
        }
    }

    public class AuthHeaderInfo
    {
        public string scheme { get; set; } // e.g., "Basic", "Bearer"
        public string username { get; set; }
        public string password { get; set; }
        public string authToken { get; set; }
        public override string ToString()
        {
            if (scheme == "Basic")
            {
                return $"{scheme} {xyTest.Base64Encode(username + ":" + password)}";
            }
            else if (scheme == "Bearer")
            {
                return $"{scheme} {authToken}";
            }
            return "";
        }
    }
}
