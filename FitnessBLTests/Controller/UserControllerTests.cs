using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {


        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //arange
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var conroller = new UserController(userName);
            //act
            conroller.SetNewUserData(gender, birthdate, weight, height);
            var conroller2 = new UserController(userName);
            //assert
            Assert.AreEqual(userName, conroller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, conroller2.CurrentUser.BirthDay);
            Assert.AreEqual(weight, conroller2.CurrentUser.Weight);
            Assert.AreEqual(height, conroller2.CurrentUser.Height);
            Assert.AreEqual(gender, conroller2.CurrentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //arange -  объявление(данные кот подаются на вход и ожидаются на выходе)
            var userName = Guid.NewGuid().ToString();

            //act - действие
            var conroller = new UserController(userName);
            //assert - проверка вывода и ввода
            Assert.AreEqual(userName, conroller.CurrentUser.Name);
            //первое должно быть равно второму
            //сравнивает по значению
            //Are.same по ссылку

        }
    }
}