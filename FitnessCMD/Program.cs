using FitnessBL.Controller;
using FitnessBL.Model;
using FitnessCMD;
using System.Globalization;
using System.Resources;
//using FitnessCMD.Languages;
//using System.Resources;

namespace FitnessCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture2 = CultureInfo.CurrentCulture;//текущая культура пользваотеля
            var culture = CultureInfo.CreateSpecificCulture("en-us");//пользователь так может изменить культуру
            var resourceManages = new ResourceManager("FitnessCMD.Languages.Manages",typeof(Program).Assembly);

            Console.WriteLine(Languages.Manages.Hello);//без resourceManages

            Console.WriteLine(resourceManages.GetString("EnterName"));//без культуры

            Console.WriteLine(resourceManages.GetString("EnterName", culture));//с культурой
                                                                      //  Console.WriteLine(Langua);
            var name = Console.ReadLine();
            //YG9NW - 3K39V - 2T3HJ - 93F3Q - G83KT
            //    PD3PC - RHNGV - FXJ29 - 8JK7D - RJRJK
            //    XQNVK - 8JYDB - WJ9W3 - YJ8YR - WFG99
            var userController = new UserController(name);
            var eatingController = new EatingConroller(userController.CurrentUser);
            var workoutController = new WorkoutController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("А - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var work = EnterWorkout();
                        workoutController.Add(work.Activity, work.Begin, work.End);
                        foreach(var item in workoutController.Workouts)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                            break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }
            }


            Console.ReadLine();
        }

        private static (DateTime Begin,DateTime End,Activity Activity) EnterWorkout()
        {
            Console.WriteLine("Введите название упражнения");
            var name = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту");


            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);


            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}