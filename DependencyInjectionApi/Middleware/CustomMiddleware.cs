using DependencyInjectionApi.Utility;

namespace DependencyInjectionApi.Middleware
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        private IOperationTransient _transient;
        private IOperationSingleton _singleton;

        public CustomMiddleware(RequestDelegate next, IOperationTransient transient, IOperationSingleton singleton)
        {
            _next = next;
            _transient = transient;
            _singleton = singleton;
        }

        public async Task InvokeAsync(HttpContext context, IOperationScoped scoped)
        {
            Console.WriteLine($"Middleware; TransientId: {_transient.OperationId} ScopedId: {scoped.OperationId} SingletonId: {_singleton.OperationId}");
            
            await _next(context);
        }
    }

    //todo: split this into another class
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}