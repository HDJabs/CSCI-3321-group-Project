using System.Runtime.CompilerServices;

namespace NewExerciseLog.UI.Models
{
    public class DBHelper
    {

        public static int IDofUserLoggedIn;

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            return config.GetConnectionString("ConnectionString");
        }

        public static void setId(int id)
        {
            IDofUserLoggedIn = id;
        }

        public static int getId() {
            return IDofUserLoggedIn;
        }

    }
}
