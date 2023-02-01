namespace DependencyInjectionApi.DataServices
{
    public class HttpDataService : IDataService
    {
        public string GetProductData(string url)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---> Getting product data...");
            Console.ResetColor();
            
            return "Product data...";
        }
    }
}