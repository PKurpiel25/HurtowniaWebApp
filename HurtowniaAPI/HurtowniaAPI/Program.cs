using HurtowniaAPI.Entities;
using HurtowniaAPI.Services;
using HurtowniaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:JwtIssuer"],
        ValidAudience = builder.Configuration["Authentication:JwtIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtKey"])),
    };
})
.AddCookie("Identity.Application")
.AddCookie("Identity.External")
.AddCookie("Identity.TwoFactorUserId");

builder.Services.AddDbContext<HurtowniaDbContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:HurtowniaAPIContext"]));

builder.Services.AddIdentityCore<Użytkownik>(options =>
{
    options.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<HurtowniaDbContext>()
.AddSignInManager();

builder.Services.AddScoped<IKontoService, KontoService>();
builder.Services.AddScoped<IProduktService, ProduktService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IZamówienieService, ZamówienieService>();
builder.Services.AddScoped<IZapytanieService, ZapytanieService>();
builder.Services.AddScoped<IZdjęcieService, ZdjęcieService>();
builder.Services.AddScoped<IRodzajPrzesyłkiService, RodzajPrzesyłkiService>();
builder.Services.AddScoped<IRodzajPłatnościService, RodzajPłatnościService>();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

await app.SeedDataAsync();

app.Run();