using CarDealer.BusinessLogic.Queries;
using MediatR;
using CarDealer.BusinessLogic.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// not really


builder.Services.AddBuisnessServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetAllCarsQuery).Assembly);

var app = builder.Build(); //todo Thrown an error

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*app.UseAuthorization();*/

app.MapControllers();

app.Run();
