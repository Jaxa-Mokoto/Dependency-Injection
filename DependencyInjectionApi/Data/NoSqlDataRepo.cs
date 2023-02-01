using DependencyInjectionApi.DataServices;

namespace DependencyInjectionApi.Data
{
    public class NoSqlDataRepo : IDataRepo
    {
        private IDataService _dataService;

        //Example of Constructor Dependency Injection:
        // ctor + tab - creates a template for a constructor method
        // _ 'underscores' represent private fields
        public NoSqlDataRepo(IDataService dataService)
        {
            // gets the value that is injected into the constructor
            _dataService = dataService;
        }
        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("---> Getting data from SQL database...");
            _dataService.GetProductData("https://something.com.api");
            Console.ResetColor();

            return("No SQL Data from DB");
        }
    }
}