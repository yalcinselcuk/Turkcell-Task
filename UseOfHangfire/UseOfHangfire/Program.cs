using Hangfire;
using UseOfHangfire.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var hangfireConnectionString = "Data Source=YALCINSELCUK-AC;Integrated Security=True;Initial Catalog=HangfireDemo;Connect " +
                                "Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
builder.Services.AddHangfire(db =>
{
    db.UseSqlServerStorage(hangfireConnectionString);
    RecurringJob.AddOrUpdate<HangfireDbContext>(h => h.GetNames(), "*/5 * * * *");
});
builder.Services.AddHangfireServer();

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
app.UseHangfireDashboard();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
