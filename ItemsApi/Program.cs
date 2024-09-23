// program.cs
using ItemsApi.AppDataContext;
using ItemsApi.Middleware;
using ItemsApi.Models;
using ItemsApi.Services;
using ItemsApi.Interface;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureApp(app);

app.Run();

// Méthode pour configurer les services
static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddExceptionHandler<GlobalExceptionHandler>();

    services.Configure<DbSettings>(configuration.GetSection("DbSettings"));
    services.AddSingleton<ItemDbContext>();
    services.AddScoped<IItemServices, ItemServices>();

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularApp", policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });
}

// Méthode pour configurer l'application
static void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowAngularApp");
    app.UseAuthorization();
    app.MapControllers();
}