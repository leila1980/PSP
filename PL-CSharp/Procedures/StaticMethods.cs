using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PL_CSharp.Procedures
{
    public static class StaticMethods
    {
        public static string ListToString(this List<string> list)
                => string.Join(",", list.ToArray());

    }
}
