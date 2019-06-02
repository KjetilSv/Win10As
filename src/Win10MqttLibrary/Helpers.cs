using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10MqttLibrary
{
    static public class Helpers
    {

            public static bool IsEmptyOrWhitespaced(this string text)
            {
                return string.IsNullOrWhiteSpace(text);
            }

    }
}
