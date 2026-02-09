using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyRESTTestLib
{
    public class RheaderTools
    {
        public static string? HeaderAuth(AuthHeaderInfo authHeaderInfo)
        {
            string? header = null;
            switch (authHeaderInfo.scheme)
            {
                case "Basic":
                    header = HeaderAuthBasic(
                        authHeaderInfo.username,
                        authHeaderInfo.password);
                    break;
                case "Bearer":
                    header = HeaderAuthBearer(authHeaderInfo.authToken);
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

    public struct AuthHeaderInfo
    {
        public string scheme; // e.g., "Basic", "Bearer"
        public string username;
        public string password;
        public string authToken;
    }
}
