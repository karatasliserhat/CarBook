using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Mappings;
using UdemyCarBook.Persitence.Context;
using UdemyCarBook.Persitence.Repositories;
using UdemyCarBook.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("corsPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7009").AllowCredentials().AllowAnyMethod().AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddDbContext<CarBookContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ServerDbConnect"]);
});


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();


builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(MapProfile).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<MyHub>("/myhub");
app.MapControllers();

app.Run();
