using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private float bouncyVelocity;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
                                                                
        if(player != null)
        {
            var rb = player.GetComponent<Rigidbody2D>();
                                                                
            if(rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, bouncyVelocity);
            }
        }
    }
}
