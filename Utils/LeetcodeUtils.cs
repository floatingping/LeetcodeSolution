using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace LeetcodeSolution.Utils
{
    public static class LeetcodeUtils
    {
        public static T ConvertToObject<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }

    }
}
