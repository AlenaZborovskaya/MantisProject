using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace MantisProject
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) 
       : base(manager)
        { }

        public int GetProjectCount()
        {
            return driver.FindElements(By.XPath("//table[3]/tbody/tr[@class='row-1' or @class='row-2']/td/a")).Count;
        }

        private List<ProjectData> projectsCashe = null;

        public List<ProjectData> GetAllProjects()
        {
            if (projectsCashe == null) //если кэш еще не заполнен то заполняем его
            {
                projectsCashe = new List<ProjectData>();
                var rows = driver.FindElements(By.XPath("//table[3]/tbody/tr[@class='row-1' or @class='row-2']"));
                foreach (var element in rows)
                {
                    var cells = element.FindElements(By.TagName("a"));
                    string name = cells[0].Text;
                    //string description = cells[1].Text;

                    projectsCashe.Add(new ProjectData()
                    {
                        Name = name,
                       // Description = description
                    });
                }
            }
            return new List<ProjectData>(projectsCashe);
        }

          

            //var rows = driver.FindElements(By.XPath("//table[3]/tbody/tr[@class='row-1' or @class='row-2']"));
            // foreach (var row in rows)
            // {
            //    string name = row.Text;
            //   string href = row.GetAttribute("href");
            //     Match m = Regex.Match(href, @"\d=$");
            //   string id = m.Value;



           



        public ProjectManagementHelper Create(ProjectData project)
        {
            CreationProject();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper Remove()
        {
            SelectProject();
            DeleteProject();
            SubmitRemoval();
            return this;

        }

        public ProjectManagementHelper SubmitRemoval()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
            return this;
        }

        public ProjectManagementHelper DeleteProject()
        {
            driver.FindElement(By.CssSelector("form > input.button")).Click();
            return this;
        }

        public ProjectManagementHelper SelectProject()
        {
            driver.FindElement(By.XPath("(//tbody)[3]/tr[3]/td/a")).Click();
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Description);
            return this;
        }

        public ProjectManagementHelper CreationProject()
        {
            driver.FindElement(By.CssSelector("td.form-title > form > input.button-small")).Click();
            return this;
        }
      
        }
    }

