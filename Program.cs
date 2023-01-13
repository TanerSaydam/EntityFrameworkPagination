using EntityFrameworkPagination.Context;
using EntityFrameworkPagination.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-3BJ5GK9;Initial Catalog=PaginationDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var db = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Products.Any())
    {
        IList<Product> products = new List<Product>();
        for (int i = 0; i < 1000; i++)
        {
            var product = new Product { Name = "Product" + (i+1), Price = (i + 1) * 10 };
            products.Add(product);
        }

        db.Products.AddRange(products);
        db.SaveChanges();
    }
}

app.Run();
