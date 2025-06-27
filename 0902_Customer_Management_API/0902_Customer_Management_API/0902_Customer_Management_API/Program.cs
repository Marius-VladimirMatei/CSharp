
using System.Reflection;
using _0902_Customer_Management_API.Data;
using _0902_Customer_Management_API.Repositories;
using _0902_Customer_Management_API.Services;
using Microsoft.OpenApi.Models;




/// <summary>
/// Sets up the ASP.NET Core application and configures services.
/// </summary>>


/// <summary>
/// Create a new web application builder
/// WebApplication is the main entry point for ASP.NET Core applications
/// Builder registers services and configures the application pipeline before building the app
/// </summary>>
var builder = WebApplication.CreateBuilder(args);

/// <summary>>
/// 1. Register ADO.NET connection factory
/// AddSingleton registers a service as a singleton - meaning only one instance will be created and used throughout the application lifetime
/// </summary>>
builder.Services.AddSingleton<IDbConnectionFactory, MySqlConnectionFactory>();



/// <summary>>
/// 2. Register repository + validation service
/// AddScoped registers a service with a scoped lifetime - meaning a new instance is created for each HTTP request
/// </summary>>
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(); // database access layer
builder.Services.AddScoped<IValidationService, ValidationService>(); // validation service for business logic and data validation


/// <summary>>
/// 3. Add controllers
/// AddControllers adds support for controllers in the application
/// </summary>>
builder.Services.AddControllers(); // enables the controllers to handle HTTP requests and responses


/// <summary>>
/// 4. Add Swagger/OpenAPI support
/// This allows for automatic generation of API documentation and interactive API testing
/// </summary>>
builder.Services.AddEndpointsApiExplorer(); // Adds support for API endpoint discovery
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "_0902_Customer_Management_API",
        Version = "v1",
        Description = "RESTful API for Customer management app"
    });


});

var app = builder.Build(); // Build the application from the configured services

/// <summary>>
/// 5. Middleware pipeline - a  component that processes requests and responses
/// </summary>>
if (app.Environment.IsDevelopment()) // checks if the application is running in development mode
{
    // Hosts an interactive web UI at(by default) / swagger / index.html.
    app.UseSwagger();
    // 
    app.UseSwaggerUI(c =>
    {
        // Returns the raw Swagger JSON document at http://localhost:3007/swagger/v1/swagger.json
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "_0902_Customer_Management_API V1");
        c.RoutePrefix = string.Empty; // Serve the UI at the app’s root
    });
}




// Redirect HTTP requests to HTTPS
// app.UseHttpsRedirection();
// UseAuthorization adds authorization middleware to the pipeline (best practice - to be later included)
app.UseAuthorization();

// UseExceptionHandlingMiddleware adds custom exception handling middleware to the pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Map controllers to the request pipeline
app.MapControllers();
// Starts the web server (Kestrel by default) and begins listening for HTTP requests.
app.Run();
