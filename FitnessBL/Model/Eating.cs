using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    /// <summary>
    /// Приём пищи
    /// </summary>
    /// 
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; }
        public Dictionary<Food,double> Foods { get; set; }//но лучше сделать свой класс
        public int UserId { get; set; }
        public Eating() { }
        public virtual User User { get; set; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food,double>();

        }
        public void Add(Food food,double weiht)
        {
            //проверка существует ли такая еда
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if(product == null)
            {
                Foods.Add(food, weiht);
            }
            else
            {
                Foods[product] += weiht;
            }

        }


    }
}
