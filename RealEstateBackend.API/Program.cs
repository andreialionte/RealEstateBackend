using RealEstateBackend.Application;
using RealEstateBackend.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));*/

builder.Services.AddCors(opts => opts.AddPolicy("DevCors", opts =>
{
    opts.AllowAnyHeader();
    opts.AllowAnyMethod();
    opts.AllowCredentials();
    opts.WithOrigins("http://localhost:5173");
}));

var configuration = builder.Configuration;
builder.Services.AppConfigureServices();
builder.Services.PersistenceConfigurations(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DevCors");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();