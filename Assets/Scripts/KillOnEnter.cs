using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
                                                                
        if(player != null)
        {
            player.TakeHit(damage);     
        }
    }
}
