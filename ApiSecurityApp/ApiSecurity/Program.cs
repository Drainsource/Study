using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiSecurity.Constants;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization((options =>
{
    AuthorizeOptions(options);
}));
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer((options =>
    {
        AuthenticationOptions(options, builder);
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AuthorizeOptions(AuthorizationOptions options)
{
    options.AddPolicy(PolicyConstants.MustHaveEmployeeId, policy =>
    {
        policy.RequireClaim("employeeId");
    });
    options.AddPolicy(PolicyConstants.MustBeTheOwner, policy =>
    {
        policy.RequireClaim("title", "Business Owner");
    });
    options.AddPolicy(PolicyConstants.MustBeAVeteranEmployee, policy =>
    {
        policy.RequireClaim("employeeId", "E001", "E002", "E003");
    });

    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
}

static void AuthenticationOptions(JwtBearerOptions options, WebApplicationBuilder builder)
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
        ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
            builder.Configuration.GetValue<string>("Authentication:SecretKey")))
    };
}