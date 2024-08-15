using Flunt.Notifications;
using Holding.Core.Helpers;

namespace Holding.Core.Validations.Notifications;

public partial class CustomNotification
{
    public Notifiable<Notification> IsGuid(string guidValue, string key, string message)
    {
        if (!guidValue.IsGuid())
            AddNotification(key, message);

        return this;
    }
}