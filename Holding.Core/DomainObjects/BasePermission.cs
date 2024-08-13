using Holding.Core.Enumerators;

namespace Holding.Core.DomainObjects;

public abstract class BasePermission
{
    private bool Partner { get; set; }
    private bool SuperAdministrator { get; set; }
    private bool Administrator { get; set; }
    private bool Editor { get; set; }
    private bool Participant { get; set; }
    private bool Integration { get; set; }

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