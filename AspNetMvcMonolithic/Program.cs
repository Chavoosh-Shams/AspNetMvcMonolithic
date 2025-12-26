using AspNetMvcMonolithic.ApplicationServices.Services;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models;
using AspNetMvcMonolithic.Models.Services.Contracts;
using AspNetMvcMonolithic.Models.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectDbContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonApplicationService, PersonApplicationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
