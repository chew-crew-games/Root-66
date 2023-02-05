using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public static int currentScore = 0;
    private TMP_Text scoreComponent;

    // Start is called before the first frame update
    void Start()
    {
        scoreComponent = GetComponent<TMP_Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        scoreComponent.text = $"Score: {currentScore}";
    }

    public void AddPoints(int earnedPoints)
    {
        currentScore += earnedPoints;
    }
}
