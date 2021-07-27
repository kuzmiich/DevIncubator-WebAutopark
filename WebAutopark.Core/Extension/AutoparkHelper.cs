using System;
using System.Collections.Generic;

namespace WebAutopark.Core.Extension
{
    public static class AutoparkHelper
    {
        public static T? ToEnum<T>(this string value) where T : struct => 
            Enum.TryParse(value, out T valueResult) ? valueResult : default;
    }
}
