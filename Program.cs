using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BankingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BankingContext") ?? throw new InvalidOperationException("Connection string 'BankingContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Use SQLite for both debug and production
// Use app.Environment.IsDevelopment() flag to set different connection string
builder.Services.AddDbContext<BankingContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("BankingContext")));

// builder.Services.AddDbContext<BankingContext>(options => 
//         options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerBankingContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
