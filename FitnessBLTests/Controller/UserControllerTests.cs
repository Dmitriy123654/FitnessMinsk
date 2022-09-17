using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {


        [TestMethod()]
        public void SetNewUserDataTest()
        {
            Assert.Fail();
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