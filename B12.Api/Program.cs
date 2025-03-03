using B12.Application.DI;

using B12.Infrastructure.DI;
using B12.Api.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

AddAppServices(builder.Services, builder.Configuration);
ConfigureAutoMapper(builder.Services);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void AddAppServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddInfrastructureServices(configuration);
    services.AddApplicationServices();
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(ProductProfile).Assembly);
    services.AddAutoMapper(typeof(CategoryProfile).Assembly);
    services.AddAutoMapper(typeof(TagProfile).Assembly);
}