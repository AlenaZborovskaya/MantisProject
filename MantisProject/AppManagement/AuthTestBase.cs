using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace MantisProject
{
    public class AuthTestBase : TestBase // базовый класс для всех тестов, которые требуют входа в систему (выполнить логин)
    {
        [SetUp]
        public void SetupLogin() //метод для инициализации: драйвера, помощников
        {
            app.Auth.Login(new AccountData("administrator", "root"));
        }
    }
}
