using Flunt.Notifications;
using Holding.Core.DomainObjects;
using Holding.Core.Helpers;

namespace Holding.Core.Validations.Notifications;

public partial class CustomNotification
{
    public Notifiable<Notification> HasPermission<T>(string role) where T: BasePermission
    {
        var permission =  (T)Activator.CreateInstance(typeof(T), new object[] { role.ToRole() })!;
        
        if (!permission.IsValid())
            AddNotification("Permission", "You do not have permission to perform this action");

        return this;
    }
}