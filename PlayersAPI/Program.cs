using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.GameUC;
using ApplicationLayer.UseCases.Interfaces.GameInterfaces;
using ApplicationLayer.UseCases.Interfaces.LoginInterfaces;
using ApplicationLayer.UseCases.Interfaces.PlayerInterfaces;
using ApplicationLayer.UseCases.Interfaces.VideoGameInterfaces;
using ApplicationLayer.UseCases.LoginUC;
using ApplicationLayer.UseCases.PlayerUC;
using ApplicationLayer.UseCases.VideoGameUC;
using AutoMapper;
using InfraestructureLayer;
using InfraestructureLayer.Configuration.Automapper;
using InfraestructureLayer.Interfaces;
using InfraestructureLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlayersAPI.Configuration.Automapper;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtAudience = builder.Configuration.GetSection("Jwt:Audience").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Players API",
        Description = @"API to report data about players, video games and games. <br /> 
                        To be able to run an endpoint you must first create a user and then login.",
        Version = "v1"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                      Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                      Example: 'Bearer 12345abcdef'<br /> <br />",
        Name = "Authorization",        
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "Bearer",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(PlayerProfile), typeof(PlayerApplicationProfile), typeof(PlayerDAOProfile));

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
        });


builder.Services.AddAuthorization();

//Mapper
builder.Services.AddScoped<IMapper, Mapper>();

//UseCases
builder.Services.AddScoped<IGetAllPlayersUC, GetAllPlayersUC>();
builder.Services.AddScoped<IGetPlayerByIdUC, GetPlayerByIdUC>();
builder.Services.AddScoped<ICreatePlayerUC, CreatePlayerUC>();
builder.Services.AddScoped<IUpdatePlayerUC, UpdatePlayerUC>();
builder.Services.AddScoped<IDeletePlayerUC, DeletePlayerUC>();
builder.Services.AddScoped<IGetAllGamesUC, GetAllGamesUC>();
builder.Services.AddScoped<IDeleteGameUC, DeleteGameUC>();
builder.Services.AddScoped<ICreateGameUC, CreateGameUC>();
builder.Services.AddScoped<ILoginUC, LoginUC>();
builder.Services.AddScoped<ICreateUserUC, CreateUserUC>();

builder.Services.AddScoped<IGetAllVideoGamesUC, GetAllVideoGamesUC>();
builder.Services.AddScoped<IDeleteVideoGameUC, DeleteVideoGameUC>();
builder.Services.AddScoped<ICreateVideoGameUC, CreateVideoGameUC>();

//Services
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IVideoGameService, VideoGameService>();
builder.Services.AddScoped<ILoginService, LoginService>();

//DAO
builder.Services.AddScoped<IPlayerDAO, PlayerDAO>();
builder.Services.AddScoped<IGameDAO, GameDAO>();
builder.Services.AddScoped<IVideoGameDAO, VideoGameDAO>();
builder.Services.AddScoped<ILoginDAO, LoginDAO>();

//DB Context
builder.Services.AddScoped<PlayersApiContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Players API V1");
    });
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();

app.MapControllers();

//JWT
app.UseAuthentication();
app.UseAuthorization();

app.Run();
