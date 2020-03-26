using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Editor
{
    public class LibraryAutoCopy : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        private const string SrcPath = "calc_lib/src";
        private const string DestPath = "Assets/CalcLib";

        private static void DirCopy(string src, string dest)
        {
            var srcInfo = new DirectoryInfo(src);
            var destInfo = new DirectoryInfo(dest);
            if (!destInfo.Exists)
            {
                destInfo.Create();
            }

            foreach (var info in srcInfo.GetFiles())
            {
                info.CopyTo(Path.Combine(destInfo.FullName, info.Name), true);
            }

            foreach (var info in srcInfo.GetDirectories())
            {
                DirCopy(info.FullName, Path.Combine(destInfo.FullName, info.Name));
            }
        }

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            DirCopy(SrcPath, DestPath);
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            Directory.Delete(DestPath, true);
        }
    }
}
