using System.Text.RegularExpressions;
using Holding.Core.Enumerators;

namespace Holding.Core.Helpers;

public static class Parser
{
    public static bool IsGuid(this string stringValue)
    {
        var guidPattern = @"[a-fA-F0-9]{8}(\-[a-fA-F0-9]{4}){3}\-[a-fA-F0-9]{12}";
        
        if (string.IsNullOrEmpty(stringValue)) return false;
        
        var guidRegEx = new Regex(guidPattern);
        return guidRegEx.IsMatch(stringValue);
    }
    
    public static Guid ToGuid(this string stringValue)
    {
        if (!IsGuid(stringValue)) return Guid.Empty;
        return Guid.Parse(stringValue);
    }
    
    public static Role ToRole(this string stringValue)
    {
        if (string.IsNullOrEmpty(stringValue)) return Role.Undefined;
        
        return stringValue.ToLower() switch
        {
            "master" => Role.Master,
            "superadministrator" => Role.SuperAdministrator,
            "administrator" => Role.Administrator,
            "editor" => Role.Editor,
            "participant" => Role.Participant,
            "integration" => Role.Integration,
            "undefined" => Role.Undefined,
            _ => Role.Undefined
        };
    }
}