using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHighScore : MonoBehaviour
{
    private TMP_Text highScoreText;

    void OnEnable()
    {
        highScoreText = GetComponent<TMP_Text>();
        int value = PlayerPrefs.GetInt("Highscore");
        highScoreText.SetText(value.ToString());
    }
}
