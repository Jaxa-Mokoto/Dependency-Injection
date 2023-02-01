namespace DependencyInjectionApi.Data
{
    public class SqlDataRepo : IDataRepo
    {
        public string ReturnData()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("---> Getting data from SQL database...");
            Console.ResetColor();

            return("SQL Data from DB");
        }
    }
}