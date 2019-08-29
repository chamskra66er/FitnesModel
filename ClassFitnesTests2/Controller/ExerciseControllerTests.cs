using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassFitnes.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassFitnes.Model;

namespace ClassFitnes.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activiryName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activiryName, rnd.Next(10,70));
            //
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));
            //
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}