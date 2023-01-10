using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT_Launcher.Commands;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class ProjectViewModel
    {
        VisualStudioHandler studioHandler;
        public CreateProjectCommand createProjectCommand { get; set; }
        public ProjectData projectData { get; set; }

        public ProjectViewModel()
        {
            studioHandler = new VisualStudioHandler();
            studioHandler.InitialiseVSEnv();
            projectData = new ProjectData();
            projectData.Name = "TestProject";
            projectData.Directory = @"C:\Users\Chris\Documents\Projects\";
            createProjectCommand = new CreateProjectCommand(studioHandler);
        }
    }
}
