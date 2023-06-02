using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class CustomBuildScript
{
    [MenuItem("Build/Build Windows")]
    static void PerformBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/Avec Espace/Compteur.unity" };
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.locationPathName = "./Build-CLI/BuildCompteur.exe";
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes to " + summary.outputPath);
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed to " + summary.outputPath);
        }
    }
}
