using UdemyCarBook.WebUI.Abstracts;
using UdemyCarBook.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenericConsumeApiService<,,>), typeof(GenericConsumeApiService<,,>));

builder.Services.AddHttpClient<IAboutConsumeApiService, AboutConsumeApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["ApiConsumes:BaseAddress"]);
});
builder.Services.AddHttpClient<ITestimonialConsumeApiService, TestimonialConsumeApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["ApiConsumes:BaseAddress"]);
});

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
