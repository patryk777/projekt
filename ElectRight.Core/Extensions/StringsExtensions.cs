namespace ElectRight.Core.Extensions;

using System.Globalization;

public static class StringExtensions
{
    public static string FormatText(this string text, params object[] args)
        => string.Format(CultureInfo.InvariantCulture, text, args);
}