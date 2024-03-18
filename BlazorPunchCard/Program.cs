using BlazorPunchCard.Client.Pages;
using BlazorPunchCard.Components;
using BlazorPunchCard.Components.Account;
using BlazorPunchCard.Config;
using BlazorPunchCard.Configuration;
using BlazorPunchCard.Controller;
using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Registration of Repositories
builder.Services.AddControllers();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IDashBoardRepository, DashBoardRepository>();
builder.Services.AddScoped<IPunchRepository, PunchRepository>();
builder.Services.AddScoped<IPunchCardRepository, PunchCardRepository>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserPunchCardRepository, UserPunchCardRepository>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();


builder.Services.AddScoped<PunchController>();
builder.Services.AddScoped<MailController>();
builder.Services.AddScoped<PunchCardController>();
builder.Services.AddScoped<RewardController>();
builder.Services.AddScoped<DashBoardController>();
builder.Services.AddScoped<PictureController>();

// Adding Component libraries
builder.Services.AddBlazorBootstrap(); // Bootstrap added
builder.Services.AddRadzenComponents(); // Radzen added

// Configuration for the connection string and other secrets
builder.Services.Configure<AppConfiguration>(
    builder.Configuration.GetSection(AppConfiguration.ConnectionStrings));

// Configuration for Email
builder.Services.Configure<MailConfiguration>(
    builder.Configuration.GetSection(MailConfiguration.NodeMailer));

builder.Services.AddHttpClient();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

// AddDbContext in disguise
builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//TODO: Review
app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
