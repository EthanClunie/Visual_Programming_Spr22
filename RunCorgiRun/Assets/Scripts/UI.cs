using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text ScoreText;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore(ScoreKeeper.GetScore());
    }

    public void ShowScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    public void ShowTime(string time)
    {
        TimerText.text = "Time: " + time;
    }

    public void Reset()
    {
        ShowScore(0);
        ShowTime("00:00");
    }
}
