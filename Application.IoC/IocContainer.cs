
namespace Application.IoC
{
    using Hangfire;
    using Hangfire.MemoryStorage;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using NetCore.AutoRegisterDi;
    using System.Reflection;

    public static class IocContainer
    {
        public static IServiceCollection AddDependencyInjectionInterfacesApp(this IServiceCollection services)
        {
            
            services.AddScoped<IJwtFabrica, JwtFabrica>();
            services.AddScoped<IContraseniaFabrica, ContraseniaFabrica>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            //services.AddScoped<IRestWsHelper, RestWsHelper>();
            //services.AddScoped<IAuthenticationProvider, AuthProviderService>();

            services.AddDependencyInjectionAppService();
            services.AddDependencyInjectionRepository();

            return services;
        }

        private static void AddDependencyInjectionAppService(this IServiceCollection services)
        {
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(AssemblyServicio)))
                .Where(c => c.Name.EndsWith("Servicio"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }

        private static void AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkApp, UnitOfWorkApp>();
        }

        public static IServiceCollection AddCustomAuthenticationApp(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("JwtEmisorOpciones").Get<JwtEmisorOpciones>();
            var tokenValidationParameters = new TokenValidationParameters
            {

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = jwtOptions.SymmetricSecurityKey,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.ClaimsIssuer = jwtOptions.Issuer;
                    options.IncludeErrorDetails = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenValidationParameters;
                    options.SaveToken = true;
                });
            return services;
        }

        public static IServiceCollection AddCorsApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                var urlList = configuration.GetSection("AllowedOrigin").GetChildren().ToArray()
                    .Select(c => c.Value?.TrimEnd('/'))
                    .ToArray();
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(urlList)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddSwaggerApp(this IServiceCollection services, Type  classe)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema ChloeAtelier", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer schema.
                        <br />Enter 'Bearer' [space] and then your token in the text input below.
                        <br />Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new string[] { }
                    }
                });

                var xmlFile = Path.ChangeExtension(classe.Assembly.Location, ".xml");
                if (File.Exists(xmlFile)) c.IncludeXmlComments(xmlFile);
            });

            return services;
        }

        public static IServiceCollection AddHangfireConfig(this IServiceCollection services, IConfiguration configuration)
        {

            //services.Configure<CronJobConfig>(configuration.GetSection("CronJobConfig"));

            // Add Hangfire services.
            services.AddHangfire(config => config
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseMemoryStorage());

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            return services;
        }

        public static void AddHangfireExtension(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseHangfireDashboard();

            //int cronJobMinutes = 10;

            //if (!string.IsNullOrEmpty(configuration["CronJobConfig:Minutes"]))
            //{
            //    int minutes = Convert.ToInt32(configuration["CronJobConfig:Minutes"]);

            //    if (minutes > 59)
            //    {
            //        cronJobMinutes = 59;
            //    }
            //    else
            //    {
            //        cronJobMinutes = minutes;
            //    };
            //}

            //RecurringJob.AddOrUpdate<IJobAppService>(x => x.SentMailPerfTracker(), cronExpression: MinuteInterval(cronJobMinutes));
            //RecurringJob.AddOrUpdate<IJobAppService>(x => x.DisableObjectives(), cronExpression: Cron.Daily, InternationalTimeHelper.GetTimeZoneInfoBySpecificCountry("PE"));
            //RecurringJob.AddOrUpdate<IJobAppService>(x => x.DisableObjectivesPerfTracker(), cronExpression: Cron.Daily(), InternationalTimeHelper.GetTimeZoneInfoBySpecificCountry("PE"));
        }
    }
}