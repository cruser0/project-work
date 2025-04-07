using API.Models;
using API.Models.Middleware;
using API.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Progetto_FormativoContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddTransient<GlobalExceptionHandler>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<ICostRegistryService, CostRegistryService>();
builder.Services.AddScoped<ICustomerInvoicesService, CustomerInvoicesServices>();
builder.Services.AddScoped<ISalesService, SaleServices>();
builder.Services.AddScoped<ISupplierInvoiceCostService, SupplierInvoiceCostServices>();
builder.Services.AddScoped<ICustomerInvoiceCostService, CustomerInvoiceCostService>();
builder.Services.AddScoped<ISupplierInvoiceService, SupplierInvoiceService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IValueServices, ValueServices>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerInvoiceAmountPaidServices, CustomerInvoiceAmountPaidServices>();
builder.Services.AddScoped<ProcedureService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Secret"]);

    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,


        ValidateLifetime = true,
        RequireExpirationTime = true,
        ClockSkew = TimeSpan.Zero

    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter your token in the input below."
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});



var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
//app.MapControllers();
static void ApplyMigration<TDbContext>(IServiceScope services)
    where TDbContext : DbContext
{
    using TDbContext context = services.ServiceProvider.GetRequiredService<TDbContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    ApplyMigration<Progetto_FormativoContext>(scope);
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();

app.Run();
