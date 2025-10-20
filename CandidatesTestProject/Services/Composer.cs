using System.Reflection;
using System.Text;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Configurations;
using CandidatesTestProject.Configurations.Database;
using CandidatesTestProject.Database;
using CandidatesTestProject.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Telegram.Bot;

namespace CandidatesTestProject.Services;

public static class Composer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Options
        services.Configure<ApplicationDbConnectionSettings>(configuration.GetSection("ConnectionStrings"))
            .AddOptions<ApplicationDbConnectionSettings>()
            .BindConfiguration("ConnectionStrings")
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"))
            .AddOptions<JwtOptions>()
            .BindConfiguration("Jwt")
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.Configure<TelegramOptions>(configuration.GetSection("Telegram"))
            .AddOptions<TelegramOptions>()
            .BindConfiguration("Telegram")
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Database
        services.AddDbContextFactory<ApplicationDbContext>((serviceProvider, options) =>
            {
                var dbSettings = serviceProvider
                    .GetRequiredService<Microsoft.Extensions.Options.IOptions<ApplicationDbConnectionSettings>>()
                    .Value;
                options.UseNpgsql(dbSettings.GetConnectionString());
            }
        );

        // JWT Authentication
        var jwtSettings = configuration.GetSection("Jwt")
            .Get<JwtOptions>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings!.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                }
            );

        services.AddAuthorization();

        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IVerificationRepository, VerificationRepository>();

        // Telegram Bot
        services.AddSingleton(sp =>
            {
                var telegramOptions = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<TelegramOptions>>()
                    .Value;
                return new TelegramBotClient(telegramOptions.BotToken);
            }
        );

        // CORS
        services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            }
        );

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICandidateService, CandidateService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IVerificationService, VerificationService>();
        services.AddScoped<ITelegramService, TelegramService>();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Candidates Test Project API",
                        Version = "v1",
                        Description = "API for candidate selection and employee management"
                    }
                );

                // Add JWT authentication to Swagger
                options.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    }
                );

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                );

                // Enable XML comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }
            }
        );

        return services;
    }
}