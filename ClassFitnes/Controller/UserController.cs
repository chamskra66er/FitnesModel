using System;
using ClassFitnes.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassFitnes.Controller
{
    //реализация логики
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {/// <summary>
    /// Пользователь.
    /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string username, string genderName, DateTime birthDay,double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(username, gender, birthDay, weight, height);           
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user) // десериализация пользователя  
                {
                    User = user;
                }
            };

        }

        /// <summary>
        /// Сохранить данные пользоватля.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.CreateNew))
            {
                formatter.Serialize(fs, User);// сериализация пользователя
            };
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь.</returns>
       
    }
}
