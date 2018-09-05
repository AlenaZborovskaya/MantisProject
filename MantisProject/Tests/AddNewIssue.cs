using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;



namespace MantisProject
{
    [TestFixture]

    public class AddNewIssueTest: TestBase
    {
        [Test]

        public void AddNewIssue()
        {
            AccountData account = new AccountData("administrator", "root");
           


        IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };


            ProjectData project = new ProjectData()
            {
                Id = "1"
             };

        app.API.CreateNewIssue(account, project, issue);
        }
    }
}
