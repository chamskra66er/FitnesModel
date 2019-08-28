using System;
using ClassFitnes.Controller;
using ClassFitnes.Model;

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
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();

                Console.WriteLine("Введите дату рождения");
                var dateBirthday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Введите вес");
                var weight = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите рост");
                var height = double.Parse(Console.ReadLine());
                userController.SetNewUserData(gender, dateBirthday, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("A - прием пищи.\n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.A)
            {
               var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }


            Console.ReadLine();
            

        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();
            Console.Write("Введите вес порции: ");
            var weight =Convert.ToDouble( Console.ReadLine() );
            Console.Write("Введите калорийность: ");
            var calories = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите кол. белков: ");
            var proteins = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите кол. углеводов: ");
            var carbohydrates = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите кол. жиров: ");
            var fats = Convert.ToDouble(Console.ReadLine());


            var product = new Food(food,calories,proteins,fats,carbohydrates);
            //while (!double.TryParse(Console.ReadLine(), out double weight))
            //{}
            return (Food:product, Weight:weight);
        }
    }
}
