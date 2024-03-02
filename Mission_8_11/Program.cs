using Microsoft.EntityFrameworkCore;
using Mission_8_11.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// build out the options to use sqlite for the database
builder.Services.AddDbContext<CoolDataContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BlahConnection"]);
});

// add in the scoped repository with our two files
builder.Services.AddScoped<IStatsRepository, EFStatsRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
