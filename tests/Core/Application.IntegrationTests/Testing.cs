using Template.Base.Application.Common.Interfaces;
using Template.Base.Infrastructure.Identity;
using Template.Core.Infrastructure.Persistence;
using Template.Core.WebAPI;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[SetUpFixture]
public class Testing
{
    private static IConfigurationRoot Configuration;
    private static IWebHostEnvironment Environment;
    private static IServiceScopeFactory ScopeFactory;
    private static Checkpoint Checkpoint;
    private static string CurrentUserId;

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
	        var hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureWebHost(builder =>
            {
                // Add TestServer
                builder.UseTestServer()
                    .CaptureStartupErrors(true)
                    .UseEnvironment("Development")
                    .UseStartup<Startup>();
            })
            .UseSerilogWithHostBuilderLogger((hostBuilderContext, log) =>
                {
                    log.ReadFrom.Configuration(hostBuilderContext.Configuration);
                }, 
                preserveStaticLogger: true
            );

        var host = hostBuilder.Start();
        _scopeFactory = host.Services.GetService<IServiceScopeFactory>();

        CurrentUserService = host.Services.GetService<ICurrentUserService>() as CurrentUserService;

        Checkpoint = new Checkpoint
        {
            TablesToIgnore = new[] { "__EFMigrationsHistory" }
        };

        EnsureDatabase();
    }

    private static void EnsureDatabase()
    {
        using var scope = ScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<CoreDbContext>();

        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = ScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetService<IMediator>();

        return await mediator.Send(request);
    }

    public static async Task<string> RunAsDefaultUserAsync()
    {
        return await RunAsUserAsync("test@local", "Testing1234!");
    }

    public static async Task<string> RunAsUserAsync(string userName, string password)
    {
        using var scope = ScopeFactory.CreateScope();

        var userManager = scope.ServiceProvider.GetService<UserManager<IdentityApplicationUser>>();

        var user = new IdentityApplicationUser { UserName = userName, Email = userName };

        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            CurrentUserId = user.Id;

            return CurrentUserId;
        }

        var errors = string.Join(System.Environment.NewLine, result.ToApplicationResult().Errors);

        throw new Exception($"Unable to create {userName}.{System.Environment.NewLine}{errors}");
    }

    public static async Task ResetState()
    {
        await Checkpoint.Reset(Configuration.GetConnectionString("DefaultConnection"));
        CurrentUserId = null;
    }

    public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = ScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<CoreDbContext>();

        return await context.FindAsync<TEntity>(keyValues);
    }

    public static async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = ScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<CoreDbContext>();

        context.Add(entity);

        await context.SaveChangesAsync();
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}
