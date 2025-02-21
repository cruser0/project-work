using API.Models;
using API.Models.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Progetto_FormativoContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddScoped<ICustomerInvoicesService, CustomerInvoicesServices>();
builder.Services.AddScoped<ISalesService, SaleServices>();
builder.Services.AddScoped<ISupplierInvoiceCostService, SupplierInvoiceCostServices>();
builder.Services.AddScoped<ICustomerInvoiceCostService, CustomerInvoiceCostService>();
builder.Services.AddScoped<ISupplierInvoiceService, SupplierInvoiceService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
