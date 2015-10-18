namespace ComputerFactory.Common.Utils
{
    using System;
    using System.Linq;

    public static class RandomUtils
    {
        private static readonly Random RandomGenerator = new Random();

        public static int GenerateNumberInRange(int minValue, int maxValue) 
        {
            return RandomGenerator.Next(minValue, maxValue + 1);
        }

        public static string GenerateRandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[RandomGenerator.Next(s.Length)]).ToArray());
        }
    }
}
