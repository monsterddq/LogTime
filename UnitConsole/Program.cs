using System;
using System.Timers;

namespace UnitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //User u = new User();
            //Get<User>(u);
            //Console.WriteLine("Hello World!");
            ;
            Timer time = new Timer();
            time.Interval = 1000;
            time.Elapsed += Time_Elapsed;
            time.Start();
            Console.WriteLine(DateTime.Now.GetHashCode());
            Console.ReadLine();
        }

        private static void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.Ticks);
        }

        public static void Get<T>(T obj)
        {
            Type type = obj.GetType();
            Console.WriteLine(type.Name);
        }
    }
}
