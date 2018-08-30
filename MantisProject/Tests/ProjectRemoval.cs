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
            List<ProjectData> projects = app.Admin.GetAllProjects();

            ProjectData project = new ProjectData()
            {
                Name = "тест",
                Description = "description"
            };

            ProjectData existingProject =  projects.Find(x => x.Name == project.Name);
            if (existingProject != null)
            {
                app.Admin.DeleteProject(existingProject);

            }
        }
    }
}
