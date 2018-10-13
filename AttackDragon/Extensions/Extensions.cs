﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttackDragon.Extensions
{
    public static class Extensions
    {
        public static string MethodStandardName(this string name)
            => name.Replace("set_", string.Empty)
            .Replace("get_", string.Empty)
            .Replace("add_", string.Empty)
            .Replace("remove_", string.Empty);
    }
}
