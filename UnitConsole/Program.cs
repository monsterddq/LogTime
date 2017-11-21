using System;

namespace UnitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            Get<User>(u);
            Console.WriteLine("Hello World!");
        }

        public static void Get<T>(T obj)
        {
            Type type = obj.GetType();
            Console.WriteLine(type.Name);
        }
    }
}
