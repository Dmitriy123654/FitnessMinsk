namespace FitnessBL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    /// 
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// День Рождения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        public int Age
        {

            get { return DateTime.Now.Year - BirthDay.Year; }
        }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthday">День Рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name,
            Gender gender,
            DateTime birthday,
            double weight,
            double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя пользователя не может быть пустным или null.");
            }
            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender), "Пол не может быть null.");
            }
            if (birthday < DateTime.Parse("01.01.1900.") || birthday >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthday));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException(nameof(weight), "Вес не может быть меньше либо равен нулю.");
            }
            if (height <= 0)
            {
                throw new ArgumentNullException(nameof(height), "Рост не может быть меньше либо равен нулю.");
            }
            #endregion

        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя пользователя не может быть пустным или null.");
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
