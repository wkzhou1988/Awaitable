using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class BuildTools 
{
    [MenuItem("Build/Android")]
    public static void BuildAndroid() {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.Android;
        options.locationPathName = "out.apk";
        BuildPipeline.BuildPlayer(options);
    }
}
