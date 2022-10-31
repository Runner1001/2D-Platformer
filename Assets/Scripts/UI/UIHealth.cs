using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHealth : MonoBehaviour
{
    private TMP_Text healthText; 

    void Awake()
    {
        healthText = GetComponent<TMP_Text>();  
        Player.OnHealthChange += Player_OnHealthChange;  
    }

    void OnDestroy()
    {
        Player.OnHealthChange -= Player_OnHealthChange; 
    }

    private void Player_OnHealthChange(int currentHealth) 
    {
        healthText.SetText(currentHealth.ToString());
    }
}
