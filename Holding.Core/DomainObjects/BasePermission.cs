using Holding.Core.Enumerators;

namespace Holding.Core.DomainObjects;

public abstract class BasePermission
{
    public BasePermission(Role role)
    {
        Role = role;
    }

    private bool Partner { get; set; }
    private bool SuperAdministrator { get; set; }
    private bool Administrator { get; set; }
    private bool Editor { get; set; }
    private bool Participant { get; set; }
    private bool Integration { get; set; }

    private Role Role { get; set; }

    protected void ChangePartner(bool value) => Partner = value;
    protected void ChangeSuperAdministrator(bool value) => SuperAdministrator = value;
    protected void ChangeAdministrator(bool value) => Administrator = value;
    protected void ChangeEditor(bool value) => Editor = value;
    protected void ChangeParticipant(bool value) => Participant = value;
    protected void ChangeIntegration(bool value) => Integration = value;

    protected abstract void SetPermission();

    public bool IsValid()
    {
        if (Role.Equals(Role.Partner)) return Partner;
        if (Role.Equals(Role.SuperAdministrator)) return SuperAdministrator;
        if (Role.Equals(Role.Administrator)) return Administrator;
        if (Role.Equals(Role.Editor)) return Editor;
        if (Role.Equals(Role.Participant)) return Participant;
        if (Role.Equals(Role.Integration)) return Integration;

        return false;
    }
}