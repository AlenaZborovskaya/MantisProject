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
    public class APIHelper : HelperBase
    {


        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;


            client.mc_issue_add(account.Username, account.Password, issue);
        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = projectData.Name;
                project.description = projectData.Description;
                project.id = projectData.Id;


                client.mc_project_add(account.Username, account.Password, project);
            }
        }
    }
}

