using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Restaurant_Reservation_Web.Endpoints;
using Restaurant_Reservation_Web.Services;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;


var builder = WebApplication.CreateBuilder(args);
var authService = new AuthService(builder);
authService.Configure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Reservation API",
        Version = "v1",
        Description = "A minimal API for managing reservations"
    });
});


builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IRepository<Reservation>, EfRepository<Reservation>>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRepository<Employee>, EfRepository<Employee>>();

builder.Services.AddScoped<IRepository<Order>, EfRepository<Order>>();

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IMenuItemsService, MenuItemsService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapReservationsEndPoints();
app.MapEmployeeEndpoints();
app.MapCustomerEndpoints();
app.MapOrderEndpoints();
app.MapMenuItemsEndpoints();
app.MapTokenEndpoints(builder.Configuration["JWT:secertKey"]);

app.Run();