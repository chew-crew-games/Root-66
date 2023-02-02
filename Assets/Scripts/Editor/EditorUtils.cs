using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class EditorFramerate {
  static EditorFramerate() {
    QualitySettings.vSyncCount = 0;
    Application.targetFrameRate = Screen.currentResolution.refreshRate;
  }
}
