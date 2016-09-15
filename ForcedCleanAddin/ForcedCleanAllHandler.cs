using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace ForcedCleanAddin
{
	public class ForcedCleanAllHandler : CommandHandler
	{
		protected override void Update(CommandInfo info)
			=> info.Visible = IdeApp.Workspace.IsOpen;

		protected override void Run()
		{
			var projects = IdeApp.Workspace.GetAllProjects();

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