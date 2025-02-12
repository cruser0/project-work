using Microsoft.EntityFrameworkCore;
using testapi.Models;
using testapi.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Progetto_FormativoContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddScoped<ICustomerREPO, CustomerREPO>();
builder.Services.AddScoped<ICustomerInvoicesREPO, CustomerInvoicesREPO>();
builder.Services.AddScoped<ISalesREPO, SaleREPO>();
builder.Services.AddScoped<ISupplierInvoiceCostREPO, SupplierInvoiceCostREPO>();
builder.Services.AddScoped<ISupplierInvoiceREPO, SupplierInvoiceREPO>();
builder.Services.AddScoped<ISupplierREPO, SupplierREPO>();



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
