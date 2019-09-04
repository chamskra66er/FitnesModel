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
    public class UserController:ControllerBase
    {/// <summary>
    /// Пользователь.
    /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
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
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name ==userName);
            if (CurrentUser == null)
            {       
                CurrentUser = new User(userName);
                IsNewUser = true;
                Users.Add(CurrentUser);
                Save();
            }
         
        }
        /// <summary>
        /// Получить списпок пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();           
            
        }

        public void SetNewUserData(string genderName,DateTime birthDate,double weight=1,double height = 1)//Знач.по умолч.
        {
            #region
            //if (genderName == null)
            //{
            //    throw new ArgumentNullException("Пол не может быть пустым", nameof(genderName));
            //}
            //if (genderName == null)
            //{ }
            //if (birthDate < DateTime.Parse("01.01.1919") || birthDate >= DateTime.Now)
            //{
            //    throw new ArgumentException("Неверная дата рождения", nameof(birthDate));
            //}
            //if (weight <= 0)
            //{
            //    throw new ArgumentException("Неверный вес", nameof(weight));

            //}
            //if (height <= 0)
            //{
            //    throw new ArgumentException("Неверный рост", nameof(height));
            //}
            #endregion
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить данные пользоватля.
        /// </summary>
        public void Save()
        {
            Save(Users);           
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь.</returns>
       
    }
}
