using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.EMail;
using GokalpStock.Application.Concrete.Service;
using GokalpStock.Persistence.Abstract.Repository;
using GokalpStock.Persistence.Abstract.UnitWork;
using GokalpStock.Persistence.Concrete.Context;
using GokalpStock.Persistence.Concrete.Repositories;
using GokalpStock.Persistence.Concrete.UnitWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GokalpStockContext>(x =>
{
    x.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Stocks4;Trusted_Connection=True;TrustServerCertificate=True");
});
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IUnitWork, UnitWork>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

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
