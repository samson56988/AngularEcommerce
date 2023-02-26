using AngularEcommerce.Data;
using AngularEcommerce.Domain;
using AngularEcommerce.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var context =  service.GetRequiredService<StoreContext>();
var logger = service.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    //await StoreContextSeed.SeesAsync(context);
}
catch(Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
