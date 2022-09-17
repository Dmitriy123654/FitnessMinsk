using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    /// <summary>
    /// пол
    /// </summary>
    public class Gender
    {
       /// <summary>
       /// Название
       /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name">имя поля</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// при наведении мышкой будешь их видеть!!!!!!!!!

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя поля не может быть пустым или null");
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
