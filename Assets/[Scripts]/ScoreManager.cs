using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreLabel;
    private int score = 0;

    private Vector2 scorePortrait, scoreLandscape;

    // Start is called before the first frame update
    void Start()
    {
        scorePortrait = new Vector2(-365.6f, 1236);
        scoreLandscape = new Vector2(-1152, 578);
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<TMP_Text>();
        
        SetScore(0);
    }
    public void Update()
    {
        scoreLabel.text = Screen.orientation.ToString();
        
    }

    public int GetScore()
    {
        return score;
    }

    public void ChangeOrientation()
    {

    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreLabel();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        scoreLabel.text = $"Score: {score}";
    }
}
