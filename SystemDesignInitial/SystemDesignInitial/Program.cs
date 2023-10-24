using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SystemDesignInitial.Domain.Abstractions.Queries;
using SystemDesignInitial.Domain.Abstractions.Repositories;
using SystemDesignInitial.Domain.Abstractions.Services;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.Applications.CreditLimitSpecification;
using SystemDesignInitial.Domain.Applications.RiskSpecifications;
using SystemDesignInitial.Domain.Entities;
using SystemDesignInitial.Domain.Queries.Customer;
using SystemDesignInitial.Domain.Services;
using SystemDesignInitial.Domain.Validators;
using SystemDesignInitial.Infra.Database;
using SystemDesignInitial.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();
builder.Services.AddDbContext<PostgresDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

builder.Services.AddScoped<IGetCustomersQuery, GetCustomers>();
builder.Services.AddScoped<IGetCustomerByIdQuery, GetCustomerById>();
builder.Services.AddScoped<ICustomerAggregationRepository, CustomerAggregationRepository>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddScoped<ICreditLimitService, CreditLimitService>();
builder.Services.AddScoped<IRiskService, RiskService>();

builder.Services.AddScoped<IRiskSpecification, MonthlyIncomeAbove50K>();
builder.Services.AddScoped<IRiskSpecification, MonthlyIncomeUnder1K>();
builder.Services.AddScoped<IRiskSpecification, MonthlyIncomeBetween1KAnd3K>();
builder.Services.AddScoped<IRiskSpecification, MonthlyIncomeBetween3KAnd8K>();
builder.Services.AddScoped<IRiskSpecification, MonthlyIncomeBetween8KAnd20K>();
builder.Services.AddScoped<IRiskSpecification, MonthlyIncomeBetween20KAnd50K>();

builder.Services.AddScoped<ICreditLimitSpecification, ScoreAbove60>();
builder.Services.AddScoped<ICreditLimitSpecification, ScoreUnder20>();
builder.Services.AddScoped<ICreditLimitSpecification, ScoreBetween20And40>();
builder.Services.AddScoped<ICreditLimitSpecification, ScoreBetween40And60>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();