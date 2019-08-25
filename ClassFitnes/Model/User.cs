using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassFitnes.Model
{/// <summary>
/// Пользователь.
/// </summary>

   [Serializable]
   public class User
    {
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        public User(string name,
                        Gender gender,
                        DateTime birthDate,
                        double weight,
                        double height)
        {
            #region Проверка условий ввода
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым", nameof(gender));
            }
            if (gender == null)
            { }
            if (birthDate < DateTime.Parse("01.01.1919")||birthDate>=DateTime.Now)
            {
                throw new ArgumentException("Неверная дата рождения", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Неверный вес", nameof(weight));

            }
            if (height <= 0)
            { throw new ArgumentException("Неверный рост", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
