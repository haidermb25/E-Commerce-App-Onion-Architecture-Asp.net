using Api.Endpoints;
using Domain.User.Interface;
using Domain.User.Repository;
using Domain.User.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add the services of the sql server
builder.Services.AddDbContext<AppDBContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn"), b => b.MigrationsAssembly("Model")));


//Registered the repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
//Registered the services
builder.Services.AddScoped<IUserService, UserService>();


//Here we add the cors policy authentication

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});




//Start the api endpoint explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
