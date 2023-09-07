using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class FinalStatsScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    public TextMeshProUGUI detailText;
    public TextMeshProUGUI finalRoundText;
    public ScoreManagerScript scoreManagerScript;
    public RoundManagerScript roundManagerScript;
    public CharacterScript characterScript;


    private void FixedUpdate()
    {
        UpdateScore();

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        
    }

    private void UpdateScore()
    {
        finalRoundText.text = "You Died Round: " + roundManagerScript.ShowRound();
        detailText.text = "Player: Kills: "+ scoreManagerScript.ShowKills() + " | Score: " +scoreManagerScript.ShowPoints() + " | Highscore: " + scoreManagerScript.ShowHighScore();
    }
}
