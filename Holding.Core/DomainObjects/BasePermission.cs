using Holding.Core.Enumerators;

namespace Holding.Core.DomainObjects;

public abstract class BasePermission
{
    public bool Partner { get; private set; }
    public bool SuperAdministrator { get; private set; }
    public bool Administrator { get; private set; }
    public bool Editor { get; private set; }
    public bool Participant { get; private set; }
    public bool Integration { get; private set; }

    protected abstract void SetPermission();
    
    protected void ChangePartner(bool value) => Partner = value;
    protected void ChangeSuperAdministrator(bool value) => SuperAdministrator = value;
    protected void ChangeAdministrator(bool value) => Administrator = value;
    protected void ChangeEditor(bool value) => Editor = value;
    protected void ChangeParticipant(bool value) => Participant = value;
    protected void ChangeIntegration(bool value) => Integration = value;

    public bool HasPermission(Role role)
    {
        if(role.Equals(Role.Partner)) return Partner;
        if(role.Equals(Role.SuperAdministrator)) return SuperAdministrator;
        if(role.Equals(Role.Administrator)) return Administrator;
        if(role.Equals(Role.Editor)) return Editor;
        if(role.Equals(Role.Participant)) return Participant;
        if(role.Equals(Role.Integration)) return Integration;

        return false;
    }
}