using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoin : MonoBehaviour
{
    private TMP_Text coinText;

    void Start()
    {
        coinText = GetComponent<TMP_Text>();  
    }

    void Update()
    {
        coinText.SetText(Coin.Coins.ToString()); 
    }
}
