using Holding.Core.Enumerators;

namespace Holding.Core.DomainObjects;

public abstract class BasePermission(Role role)
{
    private bool Master { get; set; } = true;
    private bool SuperAdministrator { get; set; }
    private bool Administrator { get; set; }
    private bool Editor { get; set; }
    private bool Participant { get; set; }
    private bool Integration { get; set; }
    private bool Undefined { get; set; }

    private Role Role { get; set; } = role;

    protected void SuperAdministratorHasPermission() => SuperAdministrator = true;

    protected void AdministratorHasPermission() => Administrator = true;

    protected void EditorHasPermission() => Editor = true;

    protected void ParticipantHasPermission() => Participant = true;

    protected void IntegrationHasPermission() => Integration = true;

    protected abstract void SetPermission();

    public bool IsValid()
    {
        if (Role.Equals(Role.Master))
            return Master;
        if (Role.Equals(Role.SuperAdministrator))
            return SuperAdministrator;
        if (Role.Equals(Role.Administrator))
            return Administrator;
        if (Role.Equals(Role.Editor))
            return Editor;
        if (Role.Equals(Role.Participant))
            return Participant;
        if (Role.Equals(Role.Integration))
            return Integration;
        if (Role.Equals(Role.Undefined))
            return Undefined;

        return false;
    }
}
