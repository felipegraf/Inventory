using InventoryManamegent.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddInfrastructure(builder.Configuration);
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();