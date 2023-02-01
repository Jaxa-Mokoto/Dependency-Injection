using DependencyInjectionApi.Data;
using DependencyInjectionApi.DataServices;
using DependencyInjectionApi.Middleware;
using DependencyInjectionApi.Utility;

var builder = WebApplication.CreateBuilder(args);

// Registering the service
// The service is fed the IDataRepo interface and provides an instance of a concrete class, SqlDataRepo
builder.Services.AddScoped<IDataRepo, SqlDataRepo>();
builder.Services.AddScoped<IDataService, HttpDataService>();

//example of implementation of the three types of service lifetimes
builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();

var app = builder.Build();

app.UseCustomMiddleware();

app.UseHttpsRedirection();

//Below is use of DI
app.MapGet("/getdata", (IOperationTransient transient, IOperationSingleton singleton, IOperationSingleton scoped) =>
{
    // Example of not using DI
    //var repo = new SqlDataRepo();
    //repo.ReturnData();

    Console.WriteLine($"Endpoint: TransientId: {transient.OperationId} ScopedId: {scoped.OperationId} SingletonId: {singleton.OperationId}");

    return Results.Ok();
});

app.Run();