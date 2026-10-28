// These lines were for the tutorial "test connection"
// using CheckedIn.Api;
// CheckedInContext context = new();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register CheckedInContext with ASP.NET Core's dependency injection system.
// This tells the application how to create and configure the context.
// The string argument to GetConnectionString must match the connection string's
// name in configuration. Check user secrets with "dotnet user-secrets list".
// The "=>" syntax defines a lambda expression that supplies the configuration
// instructions to AddDbContext.

builder.Services.AddDbContext<CheckedInContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CheckedInConnection")));


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
