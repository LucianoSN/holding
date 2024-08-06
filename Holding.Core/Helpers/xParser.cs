using System.Text.RegularExpressions;

namespace Holding.Core.Helpers;

public static class xParser
{
    public static bool IsGuid(this string stringValue)
    {
        var guidPattern = @"[a-fA-F0-9]{8}(\-[a-fA-F0-9]{4}){3}\-[a-fA-F0-9]{12}";
        
        if (string.IsNullOrEmpty(stringValue)) return false;
        
        var guidRegEx = new Regex(guidPattern);
        return guidRegEx.IsMatch(stringValue);
    }
}