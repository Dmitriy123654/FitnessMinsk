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

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthdate = DateTime.Parse(Console.ReadLine());
            //TODO: Переписать.

            Console.WriteLine("Введите вес");
            var weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = Double.Parse(Console.ReadLine());

            var userConroller = new UserController(name,gender,birthdate,weight,height);
            userConroller.Save();
        }
    }
}