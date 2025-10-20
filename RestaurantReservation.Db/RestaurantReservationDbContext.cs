using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Functions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Models.Views;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    public DbSet<ReservationDetail> ReservationDetails { get; set; }
    public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
        : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-7N1E1DT;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationDetail>().HasNoKey().ToView("vw_ReservationDetails");
        modelBuilder.Entity<EmployeeDetail>().HasNoKey().ToView("vw_EmployeeDetails");

        modelBuilder
            .HasDbFunction(() => RestaurantReservationsExtensions.CalculateRestaurantRevenue(default))
            .HasName("CalculateRestaurantRevenue");

        modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant
            {
                RestaurantId = 1, Name = "Sunrise Diner", Address = "123 Main St", PhoneNumber = "111-111-1111",
                OpeningHours = "08:00-22:00"
            },
            new Restaurant
            {
                RestaurantId = 2, Name = "Ocean Grill", Address = "456 Ocean Ave", PhoneNumber = "222-222-2222",
                OpeningHours = "10:00-23:00"
            },
            new Restaurant
            {
                RestaurantId = 3, Name = "Mountain Cafe", Address = "789 Hill Rd", PhoneNumber = "333-333-3333",
                OpeningHours = "07:00-21:00"
            },
            new Restaurant
            {
                RestaurantId = 4, Name = "City Bistro", Address = "321 Center St", PhoneNumber = "444-444-4444",
                OpeningHours = "09:00-22:00"
            },
            new Restaurant
            {
                RestaurantId = 5, Name = "Garden Eatery", Address = "654 Park Ln", PhoneNumber = "555-555-5555",
                OpeningHours = "08:00-20:00"
            }
        );

        modelBuilder.Entity<Table>().HasData(
            new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
            new Table { TableId = 2, RestaurantId = 2, Capacity = 6 },
            new Table { TableId = 3, RestaurantId = 3, Capacity = 2 },
            new Table { TableId = 4, RestaurantId = 4, Capacity = 4 },
            new Table { TableId = 5, RestaurantId = 5, Capacity = 8 }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com",
                PhoneNumber = "100-100-1000"
            },
            new Customer
            {
                CustomerId = 2, FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com",
                PhoneNumber = "200-200-2000"
            },
            new Customer
            {
                CustomerId = 3, FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com",
                PhoneNumber = "300-300-3000"
            },
            new Customer
            {
                CustomerId = 4, FirstName = "Diana", LastName = "White", Email = "diana@example.com",
                PhoneNumber = "400-400-4000"
            },
            new Customer
            {
                CustomerId = 5, FirstName = "Ethan", LastName = "Green", Email = "ethan@example.com",
                PhoneNumber = "500-500-5000"
            }
        );

        modelBuilder.Entity<Reservation>().HasData(
            new Reservation
            {
                ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1,
                ReservationDate = new DateTime(2025, 9, 20, 14, 0, 0), PartySize = 2
            },
            new Reservation
            {
                ReservationId = 2, CustomerId = 2, RestaurantId = 2, TableId = 2,
                ReservationDate = new DateTime(2025, 9, 21, 14, 0, 0), PartySize = 4
            },
            new Reservation
            {
                ReservationId = 3, CustomerId = 3, RestaurantId = 3, TableId = 3,
                ReservationDate = new DateTime(2025, 9, 22, 14, 0, 0), PartySize = 2
            },
            new Reservation
            {
                ReservationId = 4, CustomerId = 4, RestaurantId = 4, TableId = 4,
                ReservationDate = new DateTime(2025, 9, 23, 14, 0, 0), PartySize = 3
            },
            new Reservation
            {
                ReservationId = 5, CustomerId = 5, RestaurantId = 5, TableId = 5,
                ReservationDate = new DateTime(2025, 9, 24, 14, 0, 0), PartySize = 6
            }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "John", LastName = "Doe", Position = "Chef" },
            new Employee
                { EmployeeId = 2, RestaurantId = 2, FirstName = "Jane", LastName = "Doe", Position = "Waiter" },
            new Employee
                { EmployeeId = 3, RestaurantId = 3, FirstName = "Mike", LastName = "Ross", Position = "Manager" },
            new Employee
                { EmployeeId = 4, RestaurantId = 4, FirstName = "Rachel", LastName = "Zane", Position = "Chef" },
            new Employee
                { EmployeeId = 5, RestaurantId = 5, FirstName = "Harvey", LastName = "Specter", Position = "Manager" }
        );
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, RestaurantId = 1, Name = "Burger", Description = "Beef burger", Price = 10 },
            new MenuItem { Id = 2, RestaurantId = 2, Name = "Pizza", Description = "Cheese pizza", Price = 12 },
            new MenuItem { Id = 3, RestaurantId = 3, Name = "Pasta", Description = "Spaghetti", Price = 11 },
            new MenuItem { Id = 4, RestaurantId = 4, Name = "Salad", Description = "Greek salad", Price = 8 },
            new MenuItem { Id = 5, RestaurantId = 5, Name = "Steak", Description = "Ribeye steak", Price = 20 }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = new DateTime(2025, 9, 20, 14, 0, 0),
                TotalAmount = 20
            },
            new Order
            {
                OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = new DateTime(2025, 9, 20, 14, 0, 0),
                TotalAmount = 35
            },
            new Order
            {
                OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = new DateTime(2025, 9, 20, 14, 0, 0),
                TotalAmount = 25
            },
            new Order
            {
                OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = new DateTime(2025, 9, 20, 14, 0, 0),
                TotalAmount = 15
            },
            new Order
            {
                OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = new DateTime(2025, 9, 20, 14, 0, 0),
                TotalAmount = 50
            }
        );

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 2 },
            new OrderItem { OrderItemId = 2, OrderId = 2, MenuItemId = 2, Quantity = 1 },
            new OrderItem { OrderItemId = 3, OrderId = 3, MenuItemId = 3, Quantity = 3 },
            new OrderItem { OrderItemId = 4, OrderId = 4, MenuItemId = 4, Quantity = 1 },
            new OrderItem { OrderItemId = 5, OrderId = 5, MenuItemId = 5, Quantity = 2 }
        );
    }
}