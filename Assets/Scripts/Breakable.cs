using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player == null)                                             
            return;

        Vector2 normal = other.contacts[0].normal;   
        if(normal.y > 0)
        {
            Hit();  
        }
    }

    private void Hit()
    {
        var ps = GetComponent<ParticleSystem>();   

        ps.Play();  

        GetComponent<Collider2D>().enabled = false;   
        GetComponent<SpriteRenderer>().enabled = false;  
    }
}
