Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.AddAppConfigurations();
}
builder.Host.UseSerilog(SerilogAction.Configure);
Log.Information($"Starting {builder.Environment.ApplicationName} API up");
try
{
    IConfiguration configuration = builder.Configuration;
    Assembly assembly = Assembly.GetExecutingAssembly();
    IServiceCollection services = builder.Services;
    {
        _ = services.AddApplication(assembly);
        _ = services.AddInfrastructure(configuration);
        _ = services.AddDbContextConfigure<FriendzyBlogContext>(configuration);
        _ = services.AddAutofacConfigure(configuration);
        _ = services.AddScoped<DefaultLanguagesCreator>();
        _ = services.AddScoped<HostRoleAndUserCreator>();
        _ = services.AddScoped<InitialHostDbBuilder>();
    }

    WebApplication app = builder.Build();
    {
        _ = app.UseMiddleware<AuthContextMiddleware>();
        _ = app.AddLocalization();
        _ = app.UseRouting();
        _ = app.UseAuthentication();
        _ = app.UseAuthorization();
        _ = app.UseMiddleware<GlobalExceptionMiddleware>();
        _ = app.ConfigureEndpoints();
        _ = app.MigrateDatabase();

        app.Run();
        await app.RunAsync();
    }
}
catch (Exception ex)
{
    string type = ex.GetType().Name;

    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }

    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}