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

            ProjectData project = new ProjectData()
            {
               Name = "тест",
               Description = "description"
            };
            
            app.Navigator.GoToManageProjects();
            app.Projects.Create(project);


        }
    }
}
       