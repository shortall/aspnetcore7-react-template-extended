using Microsoft.EntityFrameworkCore;
using TemplateApp.Data.EF.Context;
using TemplateApp.Data.EF.UnitOfWork;
using TemplateApp.Domain.Contract;
using TemplateApp.WebApi.GraphQL;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DashboardDBContext>(options => options.UseInMemoryDatabase(databaseName: "TemplateAppDB"));
builder.Services.AddTransient<DbInitialiser>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors(myAllowSpecificOrigins);

app.MapGraphQL();

InitialiseDb(app);

app.Run();



static IServiceScope InitialiseDb(WebApplication app)
{
    var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;

    var initialiser = services.GetRequiredService<DbInitialiser>();

    initialiser.Run();
    return scope;
}