using Engine;
using System.Configuration.Internal;
using TwinCAT_Launcher.Core;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class ProjectViewModel
    {
        public VisualStudioHandler studioHandler { get;}
        public RelayCommand CreateProjectCommand { get; set; }  
        public ProjectData projectData { get; set; }

        public ProjectViewModel()
        {
            studioHandler = new VisualStudioHandler();
            studioHandler.InitialiseVSEnv();
            projectData = new ProjectData();
            projectData.Name = "TestProject";
            projectData.Directory = @"C:\Users\Chris\Documents\Projects\";
            CreateProjectCommand = new RelayCommand(CreateProject);
        }

        public void CreateProject(object parameter)
        {
            ProjectData projectData = (ProjectData)parameter;
            studioHandler.SetEnvVisability(true, true);
            studioHandler.CreateDirectory(projectData.Directory);
            studioHandler.CreateSolution(projectData.Name);
            studioHandler.CreateTCProj(projectData.Name);
            studioHandler.Save();
        }
    }
}
