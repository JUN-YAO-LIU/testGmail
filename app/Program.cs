var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

#region ## Add services to the container. ----------------------------------
builder.Services.AddControllersWithViews();
#endregion

#region ## Configure the HTTP request pipeline. ----------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();


app.UseEndpoints(
endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
#endregion

app.Run();
