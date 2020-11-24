using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : UI<GameHUD>
{
    public int Score { get; private set; }

    public void AddScore(int add_Score)
    {
        Score += add_Score;
        Vars["ScoreText"].GetComponent<Text>().text = $"Score : {Score}";
    }
}