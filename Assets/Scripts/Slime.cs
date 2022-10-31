using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, ITakeHit
{
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private Transform rightSensor;
    [SerializeField] private Transform leftSensor;
    [SerializeField] private int damage = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float direction = -1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(direction, rb.velocity.y); 

        if (direction > 0)            
            ScanSensor(rightSensor);             
            ScanSensor(leftSensor);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();  
                                                               
        if (player == null)                                     
            return;

        Vector2 normal = other.contacts[0].normal;     
        if (normal.y <= -0.5f)                         
            StartCoroutine(Die());                     
        else                                           
            player.TakeHit(damage);
    }

    private IEnumerator Die()
    {
        GetComponent<Animator>().enabled = false;   
        rb.simulated = false;                       
        GetComponent<Collider2D>().enabled = false; 
        sr.sprite = deadSprite;                     

        float alpha = 1;                           
        while(alpha > 0)                               
        {                                              
            alpha -= Time.deltaTime;                   
            sr.color = new Color(1, 1, 1, alpha);                       
            yield return null;                         
        }

        enabled = false;                             
    }

    private void ScanSensor(Transform sensor)
    {
        Debug.DrawRay(sensor.position, new Vector2(direction, 0) * 0.1f, Color.blue);
        var result = Physics2D.Raycast(sensor.position, new Vector2(direction, 0), 0.1f);

        if (result.collider != null)       
            TurnAround();

        Debug.DrawRay(sensor.position, Vector2.down * 0.1f, Color.red);
        var downResult = Physics2D.Raycast(sensor.position, Vector2.down, 0.1f); 

        if(downResult.collider == null)  
            TurnAround();                
    }

    private void TurnAround()
    {
        direction *= -1;              
        sr.flipX = direction > 0;     
    }

    public void TakeHit()
    {
        Destroy(this.gameObject);
    }
}
