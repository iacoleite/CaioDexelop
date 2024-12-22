using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CaioDexelop.Data;
using CaioDexelop.Migrations;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CaioDexelopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CaioDexelopContext") ?? throw new InvalidOperationException("Connection string 'CaioDexelopContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed the database if empty
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CaioDexelopContext>();
        if (context.Database.EnsureCreated())
        { //if database is created
            await UtenteSeeder.SeedAsync(context);
        }
        else
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }
            await UtenteSeeder.SeedAsync(context);
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
