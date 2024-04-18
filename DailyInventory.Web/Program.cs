using DailyInventory.DataAccess;
using DailyInventory.DataAccess.IRepository;
using DailyInventory.DataAccess.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

var Logger = new LoggerConfiguration().WriteTo.File("Logs\\DailyInventry-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Logging.AddSerilog(Logger);

builder.Services.AddScoped<IDataBase, DataBase>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customers}/{controller=Home}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();