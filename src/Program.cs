using FluentValidation;
using MinimalApi.Modules.Accounts;
using MinimalApi.Modules.Accounts.Endpoints;
using MinimalApi.Modules.Invitations;

namespace MinimalApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        
        // Enable generation of OpenAPI docs
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Services for validation
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();

        // Adding services required for modules
        builder.Services.AddAccountsModule();
        builder.Services.AddInvitationsModule();
        
        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        // Wiring up modules
        app.UseAccountsModule();
        app.UseInvitationsModule();

        app.Run();
    }
}
