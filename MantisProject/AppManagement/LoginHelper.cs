using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace MantisProject
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
        : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }    
        public void Login(AccountData account)
        {
            //проверяем, если логин уже выполнен, то повторно делать не надо
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("username"), account.Username);
            Type(By.Name("password"), account.Password);

            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        

        
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn();
            
                
        }

       
    }
}
