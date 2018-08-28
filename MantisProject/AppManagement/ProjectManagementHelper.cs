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
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) 
       : base(manager)
        { }

        

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
            driver.FindElement(By.CssSelector("[href='manage_proj_edit_page\\.php\\?project_id\\=7']")).Click();
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

