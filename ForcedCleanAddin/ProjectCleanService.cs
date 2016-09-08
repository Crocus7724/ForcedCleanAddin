using System.IO;
using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Projects;

namespace ForcedCleanAddin
{
	public class ProjectCleanService
	{
		public static void Clean(Project project, OutputProgressMonitor monitor = null)
		{
			monitor?.Log.WriteLine($"{project.Name}をクリーン...");

			project.Clean(ProgressMonitorService.CleanProgressMonitor, project.DefaultConfiguration.Selector);

			var path = project.BaseDirectory.FullPath;

			var binPath = Path.Combine(path, "bin");

			if (Directory.Exists(binPath))
			{
				Directory.Delete(binPath, true);
				monitor?.Log.WriteLine($"{binPath}を削除しました!");
			}

			var objPath = Path.Combine(path, "obj");

			if (Directory.Exists(objPath))
			{
				Directory.Delete(objPath, true);
				monitor?.Log.WriteLine($"{objPath}を削除しました!");
			}

			monitor?.Log.WriteLine("完了");
			monitor?.Log.WriteLine("");
		}
	}
}