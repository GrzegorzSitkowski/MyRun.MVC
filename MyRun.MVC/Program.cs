using MyRun.Infrastructure.Extensions;
using MyRun.Infrastructure.Seeders;
using MyRun.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

var scope = app.Services.CreateScope();

var seederRace = scope.ServiceProvider.GetRequiredService<RaceSeeder>();
var seederProfile = scope.ServiceProvider.GetRequiredService<RunnerProfileSeeder>();
var seederWorkout = scope.ServiceProvider.GetRequiredService<WorkoutSeeder>();

await seederRace.Seed();
await seederProfile.Seed();
await seederWorkout.Seed();

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
