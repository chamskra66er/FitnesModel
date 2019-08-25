using System;
using ClassFitnes.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;

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
        public List<User> Users { get; }

        public User CurrentUser { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Поле не может быть пустым",nameof(userName));
            }
            Users = new List<User>();

            CurrentUser = Users.SingleOrDefault(e=>e.Name ==userName);
            if (CurrentUser == null)
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    throw new ArgumentNullException("Поле не может быть пустым", nameof(userName));
                }
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }
         
        }
        /// <summary>
        /// Получить списпок пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersDate()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users) // десериализация пользователя  
                {
                    return users;
                }
                else
                {
                    return new List<User>();
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
                formatter.Serialize(fs, Users);// сериализация пользователя
            };
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь.</returns>
       
    }
}
