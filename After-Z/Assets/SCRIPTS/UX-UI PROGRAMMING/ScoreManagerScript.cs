using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float ScorePoints;

    public float AddScore(float num)
    {
        ScorePoints += num;
        return ScorePoints;
    }

    public float subScore(float num)
    {
        num -= num;
        ScorePoints = num;
        return ScorePoints;
    }

    private void FixedUpdate()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + ScorePoints.ToString();
    }
}
