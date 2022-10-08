using Api.Services.Ayudantes;
using Application.IoC;
using Application.Main.AutoMapper;
using Application.Security.Contrasenia;
using Application.Security.JWT;
using Infrastructure.Main.Contexto;
using SharedKernell.ConvetidoresJson;
using SharedKernell.Email;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextoPrincipal>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.Configure<ContraseniaOpciones>(builder.Configuration.GetSection("ContraseniaOpciones"));
builder.Services.Configure<JwtEmisorOpciones>(builder.Configuration.GetSection("JwtEmisorOpciones"));
builder.Services.Configure<EmailConfiguracion>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).GetTypeInfo().Assembly);
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDependencyInjectionInterfacesApp();
builder.Services.AddCustomAuthenticationApp(builder.Configuration);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    options.JsonSerializerOptions.Converters.Add(new TrimStringConverter());
});
builder.Services.AddHangfireConfig(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddMvcCore().AddRazorViewEngine();
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ProducesResponseProvider>());
builder.Services.AddControllers( op =>
{
    op.Filters.Add<AsyncActionFilter>();
});
builder.Services.AddSwaggerApp(typeof(Program));
builder.Services.AddCorsApp(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Api.Services v1"));
}

app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    //endpoints.MapHub<CaseHub>("/casehub");
});

app.Run();
