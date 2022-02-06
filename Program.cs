using Microsoft.EntityFrameworkCore;
using WebApplicationTeste.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Agencia Cronos Api", Version = "v1" });
});

var app = builder.Build();

builder.Services.AddDbContext<AgenciaCronosAPIContext>(options =>

    options.UseMySql(builder.Configuration.GetConnectionString("WebApplicationTesteContext"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agencia Cronos Api v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
