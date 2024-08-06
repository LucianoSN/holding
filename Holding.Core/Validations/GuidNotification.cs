using Holding.Core.Helpers;

namespace Holding.Core.Validations;

public partial class CustomNotification
{
    public void IsGuid(string guidValue, string key, string message)
    {
        if (!Parser.IsGuid(guidValue))
            AddNotification(key, message);
    }
}