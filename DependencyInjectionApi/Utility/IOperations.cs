namespace DependencyInjectionApi.Utility
{
    public interface IOperation
    {
        public string OperationId { get; }
    }
    
        public interface IOperationTransient : IOperation {}
        public interface IOperationScoped : IOperation {}
        public interface IOperationSingleton : IOperation {}
}