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
using Application.Interfaces.Questions;
using Application.Repositories.Questions;
using Microsoft.OpenApi.Models;
using Application.Interface.TestInterface;
using Application.Repositories.TestRepo;
using DAL.Entities;
using Api.Config;
using Microsoft.Extensions.Options;
using Api.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IJwtUtils, JwtUtils>();


// For Identity
builder.Services.AddIdentity<User, IdentityRole>(identity =>
{
    //identity.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddRoleManager<RoleManager<IdentityRole>>()
.AddSignInManager<SignInManager<User>>()
.AddUserManager<UserManager<User>>()
.AddDefaultTokenProviders();


var serviceProvider = builder.Services.BuildServiceProvider();


var jwtAthenticationOptions = serviceProvider.GetService<IOptions<JwtAthenticationOptions>>();

JwtAthenticationOptions JwtAthentication = jwtAthenticationOptions.Value;

// Adding Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = JwtAthentication.ValidAudience,
        ValidIssuer = JwtAthentication.ValidIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtAthentication.jwtKey))
    };
});
//Services

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITestRepository , TestRepository > ();

builder.Services.AddScoped<IQcmQuestionRepository, QcmQuestionRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<CandidatRepository, UserRepository>();




builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});
ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
builder.Services.Configure<JwtAthenticationOptions>(settings => configuration.Bind("JwtAthentication", settings));

var app = builder.Build();
app.UseSwagger();   
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseCors("corsapp");
app.UseHttpsRedirection();
//app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
