using FitnessBL.Controller;
using FitnessBL.Model;

namespace FitnessCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в тестовое приложение для фитнеса");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userConroller = new UserController(name);
            var eatingConroller = new EatingConroller(userConroller.CurrentUser);
            Console.WriteLine(userConroller.CurrentUser);
            if (userConroller.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userConroller.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userConroller.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingConroller.Add(foods.Food, foods.Weight);
                foreach(var item in eatingConroller.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }

            }

        }

        private static (Food Food,double Weight) EnterEating()
        { 
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food,calories,prots,fats,carbs);

            return (Food: product,Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        public static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                //var birthDate = Console.ReadLine();
                if (Double.TryParse(Console.ReadLine(), out double value))
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