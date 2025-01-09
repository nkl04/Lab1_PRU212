using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : Singleton<ScoreSystem>
{
    private int score = 0;

    public void AddScore(int score)
    {
        this.score += score;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
