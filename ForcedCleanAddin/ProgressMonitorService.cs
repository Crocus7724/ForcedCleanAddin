using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Ide;

namespace ForcedCleanAddin
{
	public class ProgressMonitorService
	{
		private static OutputProgressMonitor _outputProgressMonitor;

		public static OutputProgressMonitor OutputProgressMonitor
			=> _outputProgressMonitor ??
			   (_outputProgressMonitor = IdeApp.Workbench.ProgressMonitors
					   .GetOutputProgressMonitor("Forced Clean", IconId.Null, true, true, true));

		public static ProgressMonitor CleanProgressMonitor
			=> IdeApp.Workbench.ProgressMonitors.GetCleanProgressMonitor();
	}
}