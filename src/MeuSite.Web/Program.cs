using MeuSite.Web.Components;
using MeuSite.Shared.Contracts;
using MeuSite.Web.Services;
using MeuSite.Ui.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IResumeDataProvider, ResumeDataProvider>();
builder.Services.AddScoped<ResumePageViewModel>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(MeuSite.Ui.Routes).Assembly);

app.Run();
