using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    float score;
    TMP_Text scoreText;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = null;
    }

    public void IncreaseScore(float amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
        Debug.Log($"Current Score: {score}");
    }
}
