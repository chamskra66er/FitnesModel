using System;
using ClassFitnes.Controller;

namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            #region
            //Console.WriteLine("Введите пол пользователя");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Введите дату рождения");
            //var dateBirthday = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Введите вес");
            //var weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Введите рост");
            //var height = double.Parse(Console.ReadLine());
            #endregion
            var userController = new UserController(name);

            

        }
    }
}
