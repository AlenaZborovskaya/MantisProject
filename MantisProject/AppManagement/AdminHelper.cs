using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace MantisProject
{
    public class AdminHelper : HelperBase
    {

        private string baseURL;

        public AdminHelper(ApplicationManager manager, String baseURL)
       : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<ProjectData> GetAllProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();

           // IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_proj_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tr.row-1, table tr.row-2"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d=$");
                string id = m.Value;

                projects.Add(new ProjectData()
                {
                    Name = name,
                    Id = id
                });

            }
            return projects;
        }
            public void DeleteProject(ProjectData project)
            {
                IWebDriver driver = OpenAppAndLogin();
                driver.Url = baseURL + "/manage_proj_edit_page.php?project_id=" + project.Id;
                driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
                driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
            }

            public IWebDriver OpenAppAndLogin()
            {
                IWebDriver driver = new SimpleBrowserDriver();
                driver.Url = baseURL + "/login_page.php";
                driver.FindElement(By.Name("username")).SendKeys("administrator");
               driver.FindElement(By.Name("password")).SendKeys("root");
                driver.FindElement(By.CssSelector("input.button")).Click();
               return driver;
            
            }
        }
    }

