using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score;

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log($"Current Score: {score}");
    }
}
