
using System.Collections.Generic;
using UnityEngine;

public static class LogUtils {
  public static void PrintList<T>(List<T> list) {
    string result = "";
    foreach (var item in list) {
      result += item.ToString() + " / ";
    }
    Debug.Log(result);
  }
  public static void PrintArray<T>(T[] list) {
    string result = "";
    foreach (var item in list) {
      result += item.ToString() + " / ";
    }
    Debug.Log(result);
  }
}
