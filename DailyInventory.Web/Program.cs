using DailyInventory.DataAccess;
using DailyInventory.DataAccess.IRepository;
using DailyInventory.DataAccess.Repository;
using DailyInventory.Models.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Serilog;

var webAppBuilder = WebApplication.CreateBuilder(args);

webAppBuilder.Services.AddControllers().AddRazorRuntimeCompilation();
webAppBuilder.Services.AddControllersWithViews();

var logger = new LoggerConfiguration()
    .WriteTo.File("Logs/DailyInventory.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

webAppBuilder.Logging.AddSerilog(logger);

webAppBuilder.Services.AddDbContext<DailyInventoryContext>(options =>
    options.UseSqlServer(webAppBuilder.Configuration.GetConnectionString("DailyInventory")));

webAppBuilder.Services.AddScoped<IDataBase, DataBase>();
webAppBuilder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

webAppBuilder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; // Enable compression over HTTPS (use with caution due to security risks)
    options.Providers.Add<BrotliCompressionProvider>(); // Add specific providers if desired
    options.Providers.Add<GzipCompressionProvider>();
});

var webApp = webAppBuilder.Build();

if (!webApp.Environment.IsDevelopment())
{
    webApp.UseExceptionHandler("/Home/Error");
    webApp.UseHsts();
}

webApp.UseResponseCompression();
webApp.UseHttpsRedirection();
webApp.UseStaticFiles();
webApp.UseRouting();
webApp.UseAuthorization();

webApp.MapControllerRoute(
    name: "default",
    pattern: "{area=Customers}/{controller=Home}/{action=Login}/{id?}");

webApp.Run();