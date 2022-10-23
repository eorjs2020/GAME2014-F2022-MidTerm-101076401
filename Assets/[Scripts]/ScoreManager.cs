using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreLabel;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<TMP_Text>();
        scoreLabel.gameObject.transform.position = new Vector3(0, 0, 0);
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
