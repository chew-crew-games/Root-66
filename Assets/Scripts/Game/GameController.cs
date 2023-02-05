using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour {
  public static int currentScore = 0;
  public static int currentHealth = 3;
  [SerializeField] TMP_Text scoreComponent;
  [SerializeField] TMP_Text healthComponent;

  // Start is called before the first frame update
  void Start() {
    PlayerCarController.CrashedCarEvent += () => IncrementHealth(-1);
    Vehicle.RecipeScoreUpdate += IncrementPoints;
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
    healthComponent.text = $"Health: {currentHealth}";
    scoreComponent.text = $"Score: ${currentScore}";
  }
}
