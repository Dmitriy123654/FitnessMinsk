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
    public class EatingConrollerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userConroller = new UserController(userName);
            var eatingConroller = new EatingConroller(userConroller.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 5000), rnd.Next(50, 500));
            eatingConroller.Add(food, 100);
            //asser
            Assert.AreEqual(food.Name, eatingConroller.Eating.Foods.First().Key.Name);
        }
    }
}