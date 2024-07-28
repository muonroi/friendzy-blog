Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    _ = builder.AddAppConfigurations();
    _ = builder.AddAutofacConfiguration();
    _ = builder.Host.UseSerilog(MSerilogAction.Configure);
}
Log.Information($"Starting {builder.Environment.ApplicationName} API up");
try
{
    IConfiguration configuration = builder.Configuration;
    Assembly assembly = Assembly.GetExecutingAssembly();
    IServiceCollection services = builder.Services;
    {
        _ = services.AddApplication(assembly);
        _ = services.AddInfrastructure(configuration,
            new MTokenInfo(),
            new MPaginationConfigs());
        _ = services.AddDbContextConfigure<FriendzyBlogContext>(configuration);
        _ = services.SwaggerConfig(builder.Environment.ApplicationName);
        _ = services.AddPaginationConfigs(configuration, new MPaginationConfigs());
        _ = services.AddScopeServices(typeof(FriendzyBlogContext).Assembly);
        _ = services.AddAutoMapper(typeof(CustomMapper));
        _ = services.AddValidateBearerToken<MTokenInfo>();
    }

    WebApplication app = builder.Build();
    {
        _ = app.AddLocalization(assembly);
        _ = app.UseRouting();
        _ = app.UseAuthentication();
        _ = app.UseAuthorization();
        _ = app.ConfigureEndpoints();
        _ = app.MigrateDatabase();
        _ = app.UseMiddleware<MExceptionMiddleware>();
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