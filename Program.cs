    using Elsa.EntityFrameworkCore.Extensions;
    using Elsa.EntityFrameworkCore.Modules.Management;
    using Elsa.EntityFrameworkCore.Modules.Runtime;
    using Elsa.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using ElsaServer.Workflows;
    using ElsaServer.Activities;

    var builder = WebApplication.CreateBuilder(args);
    builder.WebHost.UseStaticWebAssets();

    var services = builder.Services;
    var configuration = builder.Configuration;
    services
        .AddElsa(elsa => elsa
            .UseIdentity(identity =>
            {
                identity.TokenOptions = options => options.SigningKey = "large-signing-key-for-signing-JWT-tokens";
                identity.UseAdminUserProvider();
            })
            .UseDefaultAuthentication()
            .UseWorkflowManagement(management =>
                management.UseEntityFrameworkCore(ef =>
                    ef.UseSqlite(configuration.GetConnectionString("Elsa"))))
            .UseWorkflowRuntime(runtime =>
                runtime.UseEntityFrameworkCore(ef =>
                    ef.UseSqlite(configuration.GetConnectionString("Elsa"))))
            .UseScheduling()
            .UseJavaScript()
            .UseLiquid()
            .UseCSharp()
            .UseHttp(http => http.ConfigureHttpOptions = options =>
                configuration.GetSection("Http").Bind(options))
            .UseWorkflowsApi()
            .AddActivitiesFrom<Program>()
            .AddWorkflow<GreetingWorkflow>() // ✅ Required to register workflow
                                             //.AddWorkflow<RunPowerShellWorkflow>()
            .AddWorkflow<SimpleShellWorkflow>()
            .AddWorkflow<MySecondPowerShellWorkflow>()
            .AddWorkflow<CheckDisk>()
            .AddWorkflow<SystemInfoWorkflow>()// ✅ Required to register workflow
        );


    services.AddCors(cors => cors.AddDefaultPolicy(policy =>
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("*")));

    //services.AddRazorPages(options =>
    //    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()));
    services.AddRazorPages(options => options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute())).AddRazorRuntimeCompilation();
    services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Pages");

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseWorkflowsApi();
    app.UseWorkflows();

    app.MapRazorPages();
    app.MapFallbackToPage("/test");
    //app.MapGet("/", async context =>
    //{
    //    await context.Response.WriteAsync("Fallback works!");
    //});


    foreach (var ep in app.Services.GetRequiredService<EndpointDataSource>().Endpoints)
    {
        Console.WriteLine(ep.DisplayName);

    }

app.Run();