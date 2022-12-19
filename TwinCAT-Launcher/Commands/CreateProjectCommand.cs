using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Engine;

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

            VisualStudioHandler.CreateDirectory(@"C:\Users\Chris\Desktop\TestProject");
            VisualStudioHandler.CreateSolution("Test");

            VisualStudioHandler.CreateTCProj("Test");

            VisualStudioHandler.Save();
        }
    }
}
