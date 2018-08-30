using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;


namespace MantisProject
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase

    {
        [Test]
        public void ProjectRemovalTest()
        {

            app.Navigator.GoToManageProjects();

            List<ProjectData> oldProjects = app.Projects.GetAllProjects();
            ProjectData tobeRemoved = oldProjects[0];

            app.Projects.Remove();

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());

            List<ProjectData> newProjects = app.Projects.GetAllProjects();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
               
                Assert.AreNotEqual(project.Name, tobeRemoved.Name);
                //Assert.AreNotEqual(project.Description, tobeRemoved.Description);
            }
        }
    }
}
