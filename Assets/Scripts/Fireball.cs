using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject fireballParticlePrefab; 
    [SerializeField] private float launchVelocity = 5; 
    [SerializeField] private int bounceLeft = 3; 
    [SerializeField] private float bounceVelocity = 3; 

    private Rigidbody2D rb;

    public float Direction { get; set; } 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(launchVelocity * Direction, rb.velocity.y); 
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        var damageable = other.collider.GetComponent<ITakeHit>(); 
        if (damageable != null)
        {
            damageable.TakeHit(); 
            Destroy(this.gameObject); 
            return; 
        }

        
        bounceLeft--; 
        if(bounceLeft < 0) 
        {
            Destroy(this.gameObject); 
        }
        else
        {
            rb.velocity = new Vector2(launchVelocity * Direction, bounceVelocity); 
            var particle = Instantiate(fireballParticlePrefab, transform.position, Quaternion.identity); 
            Destroy(particle, 1f); 
        }
    }
}
