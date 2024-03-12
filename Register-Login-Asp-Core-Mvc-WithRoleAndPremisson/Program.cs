using Application.IService;
using Application.Service;
using Domain.IRepository;
using Infrastructure.Data;
using Infrastructure.Repository;


#region Services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add DBContext
builder.Services.AddDbContext<DataContext>();

//Sevices
builder.Services.AddScoped<IUserService, UserService>();


//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


#region AppUses
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{


    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapAreaControllerRoute(
    name: "default",
    areaName: "SitePanel",
    pattern: "{controller=User}/{action=Index}/{id?}"
   );



});

#endregion

app.Run();
