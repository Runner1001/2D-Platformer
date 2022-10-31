using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform exitDoor;

    [SerializeField] private Sprite openTop;
    [SerializeField] private Sprite openMid;

    [SerializeField] private SpriteRenderer srTop;
    [SerializeField] private SpriteRenderer srMid;

    [Tooltip("Se la porta ha un canvas usa questa variabile, altrimenti no")]
    [SerializeField] private Canvas canvas;

    private bool isOpen;

    [ContextMenu("Apri la porta")] 
    public void Open()
    {
        if(canvas != null)
        {                                   
            canvas.enabled = false;
        }
        isOpen = true;   
        srTop.sprite = openTop; 
        srMid.sprite = openMid; 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!isOpen) 
            return;

        var player = other.GetComponent<Player>();
        if (player != null && exitDoor != null) 
        {
            player.TeleportTo(exitDoor.position);
        } 
    }
}
