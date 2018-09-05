using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;




namespace MantisProject
{
    public class ApplicationManager
    {
        //перенесли также из TestBase, так как в тестах не используется, драйвер только запускает и выключает браузер
        protected IWebDriver driver;
        protected string baseURL;

        public LoginHelper loginHelper { get; set; }
        public ManagementMenuHelper menuHelper { get;set; }
        public ProjectManagementHelper projectHelper { get; set; }
        public AdminHelper adminHelper { get; set; }
        public APIHelper apiHelper { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();// это объект который будет устанавливать соответствие между текущим потоком и объектом типа ApplicationManager

        
        private ApplicationManager()  
        {

            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);

            baseURL = "http://localhost/mantisbt-1.2.17";
            loginHelper = new LoginHelper(this);
            menuHelper = new ManagementMenuHelper(this);
            projectHelper = new ProjectManagementHelper(this);
            adminHelper = new AdminHelper(this, baseURL);
            apiHelper = new APIHelper(this);
        }

       
         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                
            }
        }

        public static ApplicationManager GetInstance() 
        {
            if (! app.IsValueCreated ) 
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url  = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }

            return app.Value;
        }



        public IWebDriver Driver
        {
            get
            {
                return driver;
            }


        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public ProjectManagementHelper Projects
        {
            get
            {
                return projectHelper;
            }
        }
        public ManagementMenuHelper Navigator
        {
            get
            {
                return menuHelper;
            }
        }
        public AdminHelper Admin
        {
            get
            {
                return adminHelper;
            }
        }
        public APIHelper API
        {
            get
            {
                return apiHelper;
            }
        }


    }
}
