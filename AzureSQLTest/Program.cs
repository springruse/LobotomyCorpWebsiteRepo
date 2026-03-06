using AzureSQLTest.Components;
using AzureSQLTest.Data;
using AzureSQLTest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBioWeaponable, BioWeaponDbService>();
// Test database connection
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        db.Database.CanConnect();
        Console.WriteLine("✅ Database connection successful!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Database connection failed: {ex.Message}");
    }
}

var app = builder.Build();
// Diagnostic: log effective DB and check table presence
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var conn = db.Database.GetDbConnection();
    try
    {
        Console.WriteLine($"Connection string in use: {conn}");
        Console.WriteLine($"DataSource: {conn.DataSource}");
        Console.WriteLine($"Database: {conn.Database}");
        conn.Open();

        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BioWeapons'";
            var result = cmd.ExecuteScalar();
            var tableCount = Convert.ToInt32(result);
            if (tableCount > 0)
                Console.WriteLine("✅ Table 'BioWeapons' exists in this database.");
            else
                Console.WriteLine("❌ Table 'BioWeapons' NOT found in this database. Check database and schema.");
        }

        // Optional: automatically apply pending EF migrations (use with caution in production)
        // db.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ DB diagnostic failure: {ex.Message}");
    }
    finally
    {
        if (conn.State == System.Data.ConnectionState.Open)
            conn.Close();
    }
}

// Continue pipeline...
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
