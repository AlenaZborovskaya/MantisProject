using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;


namespace MantisProject
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //готовим тестовую ситуацию
            app.Auth.Logout();
            // действия
            AccountData account = new AccountData("administrator", "root");
            app.Auth.Login(account);
            //проверка
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }
        [Test]
        public void LoginWithINvalidCredentials()
        {
            //готовим тестовую ситуацию
            app.Auth.Logout();
            // действия
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            //проверка
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
