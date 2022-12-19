using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Engine;
using TwinCAT_Launcher.Commands;

namespace TwinCAT_Launcher.ViewModels
{
    class MainViewModel
    {
        VisualStudioHandler studioHandler;
        public CreateProjectCommand createProjectCommand;

        public MainViewModel()
        {
            studioHandler= new VisualStudioHandler();
            studioHandler.InitialiseVSEnv();
            createProjectCommand = new CreateProjectCommand(studioHandler);
        }

    }
}
