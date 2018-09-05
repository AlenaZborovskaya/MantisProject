using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;


namespace MantisProject
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase

    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");

            ProjectData project = new ProjectData()
            {
               Name = "тест",
               Description = "description"
            };

            ProjectData projectData = new ProjectData()
            {
                Id = "1"
            };

            app.API.CreateNewProject(account, project);

            //app.Navigator.GoToManageProjects();
           // app.Projects.Create(project);


        }
    }
}
       