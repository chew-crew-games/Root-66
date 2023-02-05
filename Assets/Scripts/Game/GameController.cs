using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
  public static int currentScore = 0;
  public static int currentHealth = 3;
  [SerializeField] TMP_Text scoreComponent;
  [SerializeField] TMP_Text healthComponent;
  [SerializeField] TMP_Text speedComponent;
  [SerializeField] GameObject gameOverObject;

  // Start is called before the first frame update
  void Start() {
    gameOverObject.SetActive(false);
    VehicleManager.RecipeScoreUpdate += IncrementPoints;
    VehicleManager.HealthUpdate += IncrementHealth;
    Ground.LitteringFine += IncrementHealth;
  }

  void Update() {
    UpdateText();
  }

  public void IncrementPoints(int earnedPoints) {
    currentScore += earnedPoints;
    scoreComponent.text = $"Score: {currentScore}";
    UpdateText();
  }

  public void IncrementHealth(int healthDiff) {
    currentHealth += healthDiff;
    healthComponent.text = $"Health: {currentHealth}";
    UpdateText();
  }

  void UpdateText() {
    if (currentHealth < 1 || currentScore < 0) {
      GameOver();
    }
    healthComponent.text = $"Health: {currentHealth}";
    scoreComponent.text = $"Score: ${currentScore}";
    speedComponent.text = $"Speed: {(int)(70 + VehicleManager.globalVelocity * -1)} mph";
  }

  void GameOver() {
    gameOverObject.SetActive(true);
    gameOverObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: $" + currentScore;
    Time.timeScale = 0;
  }

  public void OnRetry() {
    Time.timeScale = 1;
    currentHealth = 3;
    currentScore = 0;
    VehicleManager.orders = new Dictionary<VehicleManager.Lane, VehicleManager.Order>();
    SceneManager.LoadScene("StartMenu");
  }
}
