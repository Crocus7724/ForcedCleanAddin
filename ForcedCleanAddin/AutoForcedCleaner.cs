using System;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace ForcedCleanAddin
{
    public class AutoForcedCleaner:IDisposable
    {
        private bool subscribed;
        public static AutoForcedCleaner Current { get; }=new AutoForcedCleaner();

        public AutoForcedCleaner()
        {

        }

        public IDisposable Subscribe()
        {
            if (subscribed) return null;

            IdeApp.ProjectOperations.StartBuild += OnStartBuild;
            subscribed = true;
            return this;
        }

        private void OnStartBuild(object sender, BuildEventArgs args)
        {
            if (PropertyService.Get<bool>(ForcedCleanConst.AutoFlagKey))
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


        public void Dispose() => IdeApp.ProjectOperations.StartBuild-=OnStartBuild;
    }
}