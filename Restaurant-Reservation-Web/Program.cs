using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_Reservation_Web.Endpoints;
using Restaurant_Reservation_Web.Services;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);
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

app.MapReservationsEndPoints();
app.MapEmployeeEndpoints();
app.MapCustomerEndpoints();
app.MapOrderEndpoints();
app.MapMenuItemsEndpoints();

app.Run();