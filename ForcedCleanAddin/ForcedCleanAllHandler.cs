using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace ForcedCleanAddin
{
    public class ForcedCleanAllHandler : CommandHandler
    {
        public ForcedCleanAllHandler()
        {
            AutoForcedCleaner.Current.Subscribe();
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = IdeApp.ProjectOperations.CurrentSelectedSolution != null
                           && IdeApp.ProjectOperations.CurrentSelectedBuildTarget.CanBuild(
                               IdeApp.Workspace.ActiveConfiguration);
        }

        protected override void Run()
        {
            var projects = IdeApp.ProjectOperations.CurrentSelectedSolution.GetAllProjects();

            var monitor = ProgressMonitorService.OutputProgressMonitor;

            monitor.Log.WriteLine(DateTimeOffset.Now);
            monitor.Log.WriteLine("ソリューションのクリーンを開始します");

            foreach (var project in projects)
            {
                ProjectCleanService.Clean(project, monitor);
            }

            monitor.Log.WriteLine("ソリューションのクリーンが終了しました!");
            monitor.Log.WriteLine(monitor.Log.NewLine);
        }
    }
}