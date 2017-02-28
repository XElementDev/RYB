using System;

namespace XElement.TestUtils
{
    public static class Random
    {
        public static string CreateString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
