using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
  public static int currentScore = 0;
  public static int currentHealth = 3;
  [SerializeField] TMP_Text scoreComponent;
  [SerializeField] TMP_Text healthComponent;
  [SerializeField] GameObject gameOverObject;

  // Start is called before the first frame update
  void Start() {
    gameOverObject.SetActive(false);
    PlayerCarController.CrashedCarEvent += (_) => IncrementHealth(-1);
    VehicleManager.RecipeScoreUpdate += IncrementPoints;
    VehicleManager.HealthUpdate += IncrementHealth;
    UpdateText();
    Ground.LitteringFine += IncrementHealth;
  }

  public void IncrementPoints(int earnedPoints) {
    currentScore += earnedPoints;
    scoreComponent.text = $"Score: {currentScore}";
    UpdateText();
    if (currentScore < 0) {
      GameOver();
    }
  }

  public void IncrementHealth(int healthDiff) {
    currentHealth += healthDiff;
    healthComponent.text = $"Health: {currentHealth}";
    UpdateText();
    if (currentHealth < 0) {
      GameOver();
    }
  }

  void UpdateText() {
    healthComponent.text = $"Health: {currentHealth}";
    scoreComponent.text = $"Score: ${currentScore}";
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
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
