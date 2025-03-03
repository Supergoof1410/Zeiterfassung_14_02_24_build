using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung_WPF
{
    public class Singleton
    {
        private static volatile Singleton? _instance;

        private Singleton() { }
        public static Singleton Instance
        {
            get
            {
                // DoubleLock
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }
        // Hilfsfeld für eine sichere Threadsynchronisierung
        private static object _lock = new();

        public int MonthNow { get; set; }
        public int YearNow { get; set; }

        private string? monthName;
        public string? MonthName
        {
            get { return monthName; }
            set
            {
                monthName = value;
            }
        }
    }
}
