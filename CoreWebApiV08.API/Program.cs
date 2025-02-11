using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Exceptions;
using CoreWebApiV08.API.Mapping;
using CoreWebApiV08.API.Models.Domain;
using CoreWebApiV08.API.Repositories;
using CoreWebApiV08.API.Repositories.Implementation;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Jwt API",
        Version = "v1"
    });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id=JwtBearerDefaults.AuthenticationScheme
            },
            Scheme= "Oauth2",
            Name=JwtBearerDefaults.AuthenticationScheme,
            In=ParameterLocation.Header
        },
        new List<string>()
        }
    });
});

// For Entity Framework  
builder.Services.AddDbContext<DatabaseContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ImsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

// Adding Redis service
// It adds and configures Redis distributed cache service 
builder.Services.AddStackExchangeRedisCache(options =>
{
    //This property is set to specify the connection string for Redis
    //The value is fetched from the application's configuration system, i.e., appsettings.json file
    options.Configuration = builder.Configuration["RedisCacheOptions:Configuration"];
    //This property helps in setting a logical name for the Redis cache instance. 
    //The value is also fetched from the appsettings.json file
    options.InstanceName = builder.Configuration["RedisCacheOptions:InstanceName"];
});

// Register the Redis connection multiplexer as a singleton service
// This allows the application to interact directly with Redis for advanced scenarios
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    // Establish a connection to the Redis server using the configuration from appsettings.json
    ConnectionMultiplexer.Connect(builder.Configuration["RedisCacheOptions:Configuration"]));

//versioning api
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion= new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    x.ApiVersionReader= new HeaderApiVersionReader("x-api-version");
});

//file upload size
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

//xml
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();



// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, SQLUserService>();
builder.Services.AddTransient<IDepartment, SQLDepartment>();
builder.Services.AddTransient<ICourse, SQLCourse>();
builder.Services.AddTransient<ILesson, SQLLesson>();
builder.Services.AddTransient<IHolidays, SQLHolidays>();
builder.Services.AddTransient<ITeacher, SQLTeacher>();
builder.Services.AddTransient<IClasses, SQLClasses>();
builder.Services.AddTransient<IStudentRegistration, SQLStudentRegistration>();  
builder.Services.AddTransient<IStudent, SQLStudent>();
builder.Services.AddTransient<IAttendance, SQLAttendance>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();

builder.Services.AddScoped<IFeesHead, SQLFeesHead>();
builder.Services.AddScoped<IPayment, SQLPayment>();

builder.Services.AddScoped<IFileService, SQLFileService>();
builder.Services.AddScoped<IEmployee, SQLEmployee>();
builder.Services.AddScoped<IProducts, SQLProducts>();

builder.Services.AddSingleton<IInterface, A>();
builder.Services.AddSingleton<IInterface, B>();
builder.Services.AddSingleton<IInterface, C>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddExceptionHandler<GlobalException>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").
                                              AllowAnyHeader()
                                              .AllowAnyMethod()
                                              .AllowAnyOrigin();
                      });
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options =>options.SerializerSettings.ContractResolver
    =new DefaultContractResolver());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || (app.Environment.IsProduction()))
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiCore v1"));
}

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");
app.UseAuthentication();

app.UseAuthorization();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Resources"
});

app.UseExceptionHandler((opt) => { });

app.MapControllers();

app.Run();
