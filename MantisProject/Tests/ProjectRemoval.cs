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
            app.Projects.Remove();


        }
    }
}
