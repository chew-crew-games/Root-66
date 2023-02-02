using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPSCounter : MonoBehaviour {
  [SerializeField] float _counterRefreshRate = 1f;

  TextMeshProUGUI _fpsText;
  float _timer = 0f;

  void Start() {
    _fpsText = GetComponent<TextMeshProUGUI>();
  }

  void Update() {
    if (Time.unscaledTime > _timer) {
      int fps = (int)(1f / Time.unscaledDeltaTime);
      _fpsText.SetText("FPS: " + fps);
      _timer = Time.unscaledTime + _counterRefreshRate;
    }
  }
}
