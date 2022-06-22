using ECommerseApi.Application.Validators.ProductValidators;
using ECommerseApi.Infrastructure.Filters;
using ECommerseApi.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices();
builder.Services.AddControllers(option => option.Filters.Add<ValidationFilter>())
                .AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<ProductCreateValidator>())
                    .ConfigureApiBehaviorOptions(option => option.SuppressModelStateInvalidFilter = true);
    


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            policy.WithOrigins("http://localhost:4200",
                                "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
