using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private float deltaScore;
    private float score = 0;
    private bool isStoped;    
    public static float scoreModifier;

    void Update()
    {        
        if (scoreModifier <= 1)
            scoreModifier += Time.deltaTime * deltaScore;

        if (!isStoped) 
        { 
            score += Time.deltaTime * scoreMultiplier * (1 + scoreModifier);
            scoreText.text = ((int)score).ToString();
        }
    }

    public void Stop()
    {
        isStoped = true;
    }
    
    public void ResetScore()
    {
        score = 0;
        isStoped = false;
        scoreModifier = 0;
        deltaScore = Math.Max(deltaScore, deltaScore * -1);
    }

    public float GetScore()
    {
        return score;
    }
}
