using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using Application.Authorization;
using Application;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})

// Adding Jwt Bearer
//.AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = configuration["JWT:ValidAudience"],
//        ValidIssuer = configuration["JWT:ValidIssuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
//    };
//});

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
