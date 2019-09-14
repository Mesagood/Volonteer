using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Volunteer.Commands
{
    class ConvertURL
    {
        public static string Convert(string url)
        {
            string str = ("%22" + HttpUtility.UrlEncode(url) + "%22").ToUpper();
            return str;
        }
        public static string Convert22(string url)
        {
            string str = ("%22" + (url) + "%22");
            return str;
        }
        public static string ConvertDate(string url)
        {
            string str = ("%22" + (url) + "%22");
            return str;
        }
    }
}
