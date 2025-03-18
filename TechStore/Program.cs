using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Data;
using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Infrastructure.IRepository;
using TechStore.Infrastructure.Repository;
using TechStore.Core.Entities;
using TechStore.Application.CategoryService;
using Microsoft.AspNetCore.Authentication;
using TechStore.Domain.Models;
using TechStore.Application.BrandService;
using TechStore.Application.ProductService;
using TechStore.Domain.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Service Injected
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Category>, CategoryService>();
builder.Services.AddScoped<ICustomService<Brand>, BrandService>();
builder.Services.AddScoped<ICustomService<ProductDto>, ProductService>();
#endregion


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
