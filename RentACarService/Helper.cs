using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RentACarService
{
   public static class Helper
    {
        public static string CONNECTION_STRING = @"Data Source=DESKTOP-2O9H0V5\Bogdan;" +
            "Initial Catalog=Rent_A_Car; MultipleActiveResultSets=True;" +
            "Integrated Security=True";

        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
        
    }
}
