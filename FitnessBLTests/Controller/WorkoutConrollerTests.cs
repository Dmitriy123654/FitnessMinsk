using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBL.Model;

namespace FitnessBL.Controller.Tests
{
    [TestClass()]
    public class WorkoutConrollerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var workoutController = new WorkoutController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            // Act
            workoutController.Add(activity,DateTime.Now,DateTime.Now.AddHours(1));
            // Assert
            Assert.AreEqual(activityName, workoutController.Activities.First().Name);
        }
    }
}