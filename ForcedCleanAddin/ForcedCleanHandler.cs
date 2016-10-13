using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace ForcedCleanAddin
{
    public class ForcedCleanHandler : CommandHandler
    {
        protected override void Update(CommandInfo info)
        {
            if (IdeApp.ProjectOperations.CurrentSelectedBuildTarget == null)
                info.Enabled = false;
            else
            {
                info.Enabled = IdeApp.ProjectOperations.CurrentSelectedBuildTarget.CanBuild(
                    IdeApp.Workspace.ActiveConfiguration);
                info.Text = "Forced Clean "
                            + IdeApp.ProjectOperations.CurrentSelectedBuildTarget.Name.Replace("_", "__");
            }
        }

        protected override void Run()
        {
            var monitor = ProgressMonitorService.OutputProgressMonitor;

            monitor.Log.WriteLine(DateTimeOffset.Now);
            monitor.Log.WriteLine("プロジェクトのクリーンを開始します");

            ProjectCleanService
                .Clean(IdeApp.Workbench.ActiveDocument.Project, monitor);

            monitor.ReportSuccess("プロジェクトをクリーンしました!");
        }
    }
}