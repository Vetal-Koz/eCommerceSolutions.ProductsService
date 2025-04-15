using eCommerce.Api.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infastructure;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductsDbContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnections"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});

builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

builder.Services.AddInfastructure();
builder.Services.AddCore();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();
//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();

