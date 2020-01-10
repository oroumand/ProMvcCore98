using System;
using System.Collections.Generic;
using System.Text;

namespace Session08.Entities
{
    public static partial class Helper
    {
        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }


    }
    public static class YeKe
    {
        public const char ArabicYeWithOneDotBelow = (char)1568;
        public const char ArabicYeWithHighHamze = (char)1574;
        public const char ArabicYeWithInvertedV = (char)1597;
        public const char ArabicYeWithTowDotsAbove = (char)1598;
        public const char ArabicYeWithThreeDotsAbove = (char)1599;
        public const char ArabicYeWithTowDotsBelow = (char)1610;
        public const char ArabicYeWithHighHamzeYeh = (char)1656;
        public const char ArabicYeWithFinalFrom = (char)1744;
        public const char ArabicYeWithThreeDotsBelow = (char)1745;
        public const char ArabicYeWithTail = (char)1741;
        public const char ArabicYeSmallV = (char)1742;

        public const char PersianYeChar = (char)1740;

        public const char ArabicKeChar = (char)1603;
        public const char PersianKeChar = (char)1705;

        public static string ApplyPersianYeKe(this string data)
        {
            return data == null
                ? null
                : (string.IsNullOrWhiteSpace(data)
                    ? string.Empty
                    : data.Replace(ArabicYeWithOneDotBelow, PersianYeChar)
                        .Replace(ArabicYeWithHighHamze, PersianYeChar)
                        .Replace(ArabicYeWithInvertedV, PersianYeChar)
                        .Replace(ArabicYeWithTowDotsAbove, PersianYeChar)
                        .Replace(ArabicYeWithThreeDotsAbove, PersianYeChar)
                        .Replace(ArabicYeWithTowDotsBelow, PersianYeChar)
                        .Replace(ArabicYeWithHighHamzeYeh, PersianYeChar)
                        .Replace(ArabicYeWithFinalFrom, PersianYeChar)
                        .Replace(ArabicYeWithThreeDotsBelow, PersianYeChar)
                        .Replace(ArabicYeWithTail, PersianYeChar)
                        .Replace(ArabicYeSmallV, PersianYeChar)

                        .Replace(ArabicKeChar, PersianKeChar).Trim());
        }
    }

}
