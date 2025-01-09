using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AplikacjaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BugTrackingDBConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Zgloszenia}/{action=Index}/{id?}"
);

app.Run();
