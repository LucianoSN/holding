using Flunt.Notifications;
using Holding.Core.DomainObjects;

namespace Holding.Core.Validations.Notifications;

public partial class CustomNotification
{
    public Notifiable<Notification> HasPermission(BasePermission permission)
    {
        if (!permission.IsValid())
            AddNotification("Permission", "You do not have permission to perform this action");

        return this;
    }
}