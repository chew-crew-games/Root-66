using UnityEngine;

public class PauseController : MonoBehaviour {
  // Consider changing pause method from using TimeScale
  [SerializeField] protected GameObject _pauseMenuOverlay;

  bool _isPauseMenuActive = false;

  void Start() {
    GameInput.PlayerPauseEvent += OnPressPause;
  }

  public void UnpauseGame() {
    Debug.Log("Unpaused game");

    Time.timeScale = 1;

    // Close menu
    _pauseMenuOverlay.SetActive(false);
    _isPauseMenuActive = false;
  }

  void PauseGame() {
    Debug.Log("Paused game");

    Time.timeScale = 0;

    // Open menu
    _pauseMenuOverlay.SetActive(true);
    _isPauseMenuActive = true;
  }

  void OnPressPause() {
    if (_isPauseMenuActive) {
      UnpauseGame();
    } else {
      PauseGame();
    }
  }

  void OnSelectQuitGame() {
    Application.Quit();
  }
}
