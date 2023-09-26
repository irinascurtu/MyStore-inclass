using MyStore.Domain;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDb"),
    x => x.MigrationsAssembly("MyStore.Domain")
));

//repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//services
builder.Services.AddScoped<ICategoryService, CategoryService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
