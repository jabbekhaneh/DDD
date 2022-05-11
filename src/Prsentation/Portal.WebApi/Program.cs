using Portal.EF.Migrations;
using Portal.EF.Configurations;
//-----------------------------------
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigServices(string.Empty);
//-----------------------------------
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    Runner.Main();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
