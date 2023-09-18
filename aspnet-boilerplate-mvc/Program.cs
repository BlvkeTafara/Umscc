using aspnet_boilerplate_mvc;
using aspnet_boilerplate_mvc.Services.Notifications;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.DbContextConfiguration(builder.Configuration);
builder.Services.IdentityConfiguration();
builder.Services.ServiceConfiguration();
builder.Services.HangfireConfiguration(builder.Configuration);

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
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard();
app.MapHangfireDashboard();
RecurringJob.AddOrUpdate<IEmailService>(
    x => x.SendEmail(),
    Cron.MinuteInterval(int.Parse(builder.Configuration.GetSection("EMAIL_INTERVAL").Value)));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
