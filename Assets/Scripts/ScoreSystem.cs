using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem
{
    public static event Action<int> OnScoreChange;

    public static int Highscore { get; private set; }
    public static int Score { get; private set; }

    public static void AddPoints(int points)
    {
        Score += points;
        OnScoreChange?.Invoke(Score);
        Debug.Log("Il mio punteggio è: " + Score);

        if(Score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
    }
}
