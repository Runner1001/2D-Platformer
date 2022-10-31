using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour
{
    [SerializeField] private Transform rightSensor;
    [SerializeField] private Transform leftSensor;
    [SerializeField] private int healAmount = 1;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private float direction = 1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y); 

        if (direction > 0)
            ScanSensor(rightSensor);             
        else                                     
            ScanSensor(leftSensor);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
       
        if (player == null)                                     
            return;

        player.Heal(healAmount); 
        Destroy(this.gameObject); 
    }

    private void ScanSensor(Transform sensor)
    {
        Debug.DrawRay(sensor.position, new Vector2(direction, 0) * 0.1f, Color.blue);
        var result = Physics2D.Raycast(sensor.position, new Vector2(direction, 0), 0.1f, LayerMask.GetMask("Ground")); 

        if (result.collider != null)       
            TurnAround();
    }

    private void TurnAround()
    {
        direction *= -1;              
    }
}
