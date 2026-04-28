using ClavierDOr.Components;
using Microsoft.EntityFrameworkCore;
using ClavierDOr.Data;
using ClavierDOr.Services;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=quiz.db"));

builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<PdfService>();

QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    ClavierDOr.Data.DatabaseSeeder.Initialiser(context);
}

app.Run();