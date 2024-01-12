using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter score { get; private set; }
    public Text yourScore;
    public int scoreValue;
    private int bestScoreValue;
    public Text bestScore;

    private void Awake()
    {
        if (score == null)
        {
            score = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        bestScoreValue = 0;
    }
    private void Update()
    {
        yourScore.text = $"Your score: {ScoreCounter.score.scoreValue.ToString()}";
        if (bestScoreValue < scoreValue)
        {
            bestScoreValue = scoreValue;
            bestScore.text = $"Best score: {bestScoreValue.ToString()}";
        }
    }
}
