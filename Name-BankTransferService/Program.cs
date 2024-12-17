using BankService.Infrastructure.Data;
using BankService.Infrastructure.ThirdPartyClients.Interrface;
using BankService.Infrastructure.ThirdPartyClients;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.Loader;
using FluentValidation;
using BankService.Application.Command.Transfers.Validators;
using BankService.Application.Queries.NameValidation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BankServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IThirdPartyBankClient, FCMBClient>();
builder.Services.AddTransient<IThirdPartyBankClient, AccessBankClient>();
builder.Services.AddTransient<IThirdPartyBankClientFactory, ThirdPartyBankClientFactory>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateTransferValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ValidateNameValidator>();
// Get the application assembly dynamically
var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
var applicationAssembly = Directory.GetFiles(path, "BankService.Application.dll")
    .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
    .FirstOrDefault();

if (applicationAssembly != null)
{
    builder.Services.AddMediatR(configuration =>
    {
        configuration.RegisterServicesFromAssembly(applicationAssembly);
    });
}


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
