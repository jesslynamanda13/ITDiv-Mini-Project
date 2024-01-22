using Microsoft.EntityFrameworkCore;
using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Helper;
using ITDiv_MiniProject.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("ITDIVProjek1")));

builder.Services.AddDbContext<CategoryContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("ITDIVProjek1")));

builder.Services.AddScoped<UserHelper>();
builder.Services.AddScoped<CategoryHelper>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
