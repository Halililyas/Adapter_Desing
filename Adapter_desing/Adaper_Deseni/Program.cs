using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaper_Deseni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product(new Log4netAdapter());// Hangi Teknolijiyle çalışmak istersen onu new le
            product.Save();
            Console.ReadLine();
        }
    }
    class Product
    {
         public ILogger _Logger;

        public Product(ILogger logger)
        {
            _Logger = logger;
        }

        public void Save()
        {
            _Logger.Log("User Data");
            Console.WriteLine("Save");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class HKLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged {0}",message);
        }
    }
    class Log4net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Log with Log4net {0}",message);
        }
    }
    class Log4netAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4net log4Net = new Log4net();
            log4Net.LogMessage(message);
        }
    }
}
