namespace DependencyInjectionApi.Utility
{
    public class Operation : IOperationTransient, IOperationSingleton, IOperationScoped
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }
        public string OperationId { get; }
    }
}