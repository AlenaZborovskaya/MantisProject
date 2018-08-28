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
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
        : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }
        public ManagementMenuHelper GoToManageProjects()
        {
            driver.FindElement(By.LinkText("Manage")).Click();
            driver.FindElement(By.LinkText("Manage Projects")).Click();
            return this;
        }

    }
}
