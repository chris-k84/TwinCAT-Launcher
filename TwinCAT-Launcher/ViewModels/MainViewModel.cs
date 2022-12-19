using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Engine;
using TwinCAT_Launcher.Commands;
using TwinCAT_Launcher.Models;

namespace TwinCAT_Launcher.ViewModels
{
    class MainViewModel
    {   
        VisualStudioHandler studioHandler;
        public CreateProjectCommand createProjectCommand;
        public ProjectData projectData { get; set; }

        public MainViewModel()
        {
            studioHandler= new VisualStudioHandler();
            studioHandler.InitialiseVSEnv();
            projectData = new ProjectData();
            createProjectCommand = new CreateProjectCommand(studioHandler);
            
        }

    }
}
