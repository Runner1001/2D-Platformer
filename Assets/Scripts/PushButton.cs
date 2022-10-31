using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onReleased;

    private Sprite releasedSprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        releasedSprite = sr.sprite;          
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if(player != null)
        {
            BecomePressed();         
        }
    }

    private void BecomePressed()
    {
        sr.sprite = pressedSprite; 
        onPressed.Invoke();        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if( player != null)
        {
            BecomeReleased();     
        }
    }

    private void BecomeReleased()
    {
        if(onReleased.GetPersistentEventCount() > 0) 
        {
            sr.sprite = releasedSprite;  
            onReleased.Invoke();      
        }
    }
}
