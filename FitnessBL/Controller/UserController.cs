using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Controller
{
    /// <summary>
    /// Контролле пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName,string genderName,DateTime birthday,
                                double weight,double height)
        {
            //TODO: Проверка.
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthday, weight, height);
            
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: Что делать, если пользователя не прочитали?


            }
        }
        /// <summary>
        /// Сохранить данные пльзователя
        /// </summary>
        public void Save()
        {

            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,User);
            }
        }
        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        
    }
}
