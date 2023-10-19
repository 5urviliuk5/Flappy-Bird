using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;

    void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();

        var best = PlayerPrefs.GetInt("Best");
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Best",best);
        }

        bestScoreText.text = best.ToString();
    }

    void Update()
    {
        
    }
}
