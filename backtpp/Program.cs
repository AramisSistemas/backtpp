using backtpp.Binder;
using backtpp.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Repository.Models;
using Repository.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IServiceCollection serviceCollection = builder.Services.AddDbContext<tppContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();
#region Binder

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
});
#endregion
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configure strongly typed settings objects
var appSettingsSection = builder.Configuration.GetSection("AppSettings");

builder.Services.Configure<AppSettings>(appSettingsSection);

// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            var userId = int.Parse(context.Principal.Identity.Name);
            var user = userService.GetById(userId);
            if (user == null)
            {
                // return unauthorized if user no longer exists
                context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddScoped<ILoggService, LoggService>();
builder.Services.AddScoped<IStoreProcedure, StoreProcedure>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<SecurityService>();
builder.Services.AddHttpContextAccessor();


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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
