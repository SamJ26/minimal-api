namespace MinimalApi.Modules.Invitations.Endpoints;

public sealed record GetInvitationStatusResponse
{
    public bool IsValid { get; init; }
}