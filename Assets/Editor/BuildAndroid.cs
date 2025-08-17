using System;
using System.IO;
using UnityEditor;

public static class BuildAndroid
{
    public static void BuildAAB() { Build(false); }
    public static void BuildAPK() { Build(true); }

    static void Build(bool apk)
    {
        string outputName = Environment.GetEnvironmentVariable("ANDROID_OUTPUT_NAME");
        if (string.IsNullOrEmpty(outputName)) outputName = "EternalHero_Alpha01";

        string outputDir = Environment.GetEnvironmentVariable("ANDROID_OUTPUT_DIR");
        if (string.IsNullOrEmpty(outputDir)) outputDir = "Builds/Android";

        if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);

        string ext = apk ? "apk" : "aab";
        string path = Path.Combine(outputDir, $"{outputName}.{ext}");

        var scenes = EditorBuildSettings.scenes != null && EditorBuildSettings.scenes.Length > 0
            ? Array.ConvertAll(EditorBuildSettings.scenes, s => s.path)
            : new string[] { };

        var options = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = path,
            target = BuildTarget.Android,
            options = BuildOptions.CompressWithLz4HC
        };

        EditorUserBuildSettings.buildAppBundle = !apk;

        var report = BuildPipeline.BuildPlayer(options);
        if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            throw new Exception($"Android build failed: {report.summary.result}");
        else
            UnityEngine.Debug.Log($"Android build succeeded: {path}");
    }
}
