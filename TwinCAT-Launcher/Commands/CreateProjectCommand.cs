using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Engine;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.Commands
{
    class CreateProjectCommand : ICommand
    {
        VisualStudioHandler VisualStudioHandler { get; set; }
        public CreateProjectCommand(VisualStudioHandler visualStudioHandler)
        {
            this.VisualStudioHandler = visualStudioHandler;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ProjectData projectData = (ProjectData)parameter;
            VisualStudioHandler.SetEnvVisability(true, true);
            VisualStudioHandler.CreateDirectory(projectData.Directory);
            VisualStudioHandler.CreateSolution(projectData.Name);
            VisualStudioHandler.CreateTCProj(projectData.Name);
            VisualStudioHandler.Save();
        }
    }
}
