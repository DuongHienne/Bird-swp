using BiTrap.DAO;
using BiTrap.DAO.Products;
using BiTrap.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SwpContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("swp")));

builder.Services.AddScoped<IPublicProductService, PublicProductService>();
builder.Services.AddScoped<IManageProductService, ManageProductService>();
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

app.Run();
