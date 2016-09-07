using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace ForcedCleanAddin
{
	public class ForcedCleanHandler:CommandHandler
	{
		protected override void Update(CommandInfo info)
			=> info.Visible = IdeApp.Workbench.ActiveDocument?.HasProject ?? false;

		protected override void Run()
		{
			var monitor = ProgressMonitorService.OutputProgressMonitor;

			monitor.Log.WriteLine(DateTimeOffset.Now);
			monitor.Log.WriteLine("プロジェクトのクリーンを開始します");

			ProjectCleanService
				.Clean(IdeApp.Workbench.ActiveDocument.Project,monitor);

			monitor.ReportSuccess("プロジェクトをクリーンしました!");
		}
	}
}