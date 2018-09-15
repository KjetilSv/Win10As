using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqttclient
{
    public static class StringExtensions
    {
        public static bool IsEmptyOrWhitespaced(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
        
    }
}
