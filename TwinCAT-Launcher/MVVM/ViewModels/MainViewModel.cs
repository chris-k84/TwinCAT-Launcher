using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Engine;
using TwinCAT_Launcher.Commands;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class MainViewModel
    {
        VisualStudioHandler studioHandler;
        public CreateProjectCommand createProjectCommand { get; set; }
        public ProjectData projectData { get; set; }

        public MainViewModel()
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
