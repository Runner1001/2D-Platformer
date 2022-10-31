using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        ScoreSystem.OnScoreChange += ScoreSystem_OnScoreChange;
        ScoreSystem_OnScoreChange(ScoreSystem.Score);
    }

    void OnDestroy()
    {
        ScoreSystem.OnScoreChange -= ScoreSystem_OnScoreChange;
    }

    private void ScoreSystem_OnScoreChange(int score)
    {
        scoreText.SetText(score.ToString());
    }
}
