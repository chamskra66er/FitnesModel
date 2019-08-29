using System;
using System.Globalization;
using System.Resources;
using ClassFitnes.Controller;
using ClassFitnes.Model;

namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать нужную локализацию / Choise need location \n R - ru   /   E - en");
            CultureInfo culture = null;
        sw:
            var key1 = Console.ReadKey();
            switch (key1.Key)
            {
                case ConsoleKey.R:
                    culture = CultureInfo.CreateSpecificCulture("ru-ru");
                    Console.WriteLine("\n");
                    break;
                case ConsoleKey.E:
                    culture = CultureInfo.CreateSpecificCulture("en-us");
                    Console.WriteLine("\n");
                    break;
                default:
                    goto sw;
            }
            //var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitnes.CMD.Languages.Messages",typeof(Program).Assembly); 

            Console.WriteLine(resourceManager.GetString("Hello",culture)); 
            Console.WriteLine(resourceManager.GetString("Input_name", culture));
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
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine(Languages.Messages.Input_gender);
                var gender = Console.ReadLine();

                Console.WriteLine(resourceManager.GetString("dateBirthday", culture));
                var dateBirthday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine(resourceManager.GetString("weight", culture));
                var weight = double.Parse(Console.ReadLine());

                Console.WriteLine(resourceManager.GetString("height", culture));
                var height = double.Parse(Console.ReadLine());
                userController.SetNewUserData(gender, dateBirthday, weight, height);              
            }

            while (true)
            {
                Console.WriteLine(userController.CurrentUser);
                Console.WriteLine(resourceManager.GetString("doing", culture));
                Console.WriteLine(resourceManager.GetString("eating", culture));
                Console.WriteLine("B - упражнения.");
                Console.WriteLine("E - выход.");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.B:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }           
        }


        //end main
        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения");
            var name = Console.ReadLine();

            Console.WriteLine("Введите расход энергии в минуту");
            var energy =Convert.ToDouble( Console.ReadLine() );
            Console.WriteLine($"Введите время начала {name}");
            var begin = Convert.ToDateTime( Console.ReadLine() );
            Console.WriteLine($"Введите время окончания {name}");
            var end = Convert.ToDateTime(Console.ReadLine());
            var activity = new Activity(name, energy);
            return (begin,end,activity);
        }
        //кортж
        private static (Food Food,double Weight) EnterEating()
        {
            Console.Write("\nВведите имя продукта: ");
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
