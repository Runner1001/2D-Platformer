using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour, ITakeHit
{
    [SerializeField] private float speed;
    [SerializeField] private float radius;

    private Vector2 center;
    private float angle;

    void Start()
    {
        center = transform.position;  
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        angle += speed * Time.deltaTime; 

        float xOffset = Mathf.Sin(angle); 
        float yOffset = Mathf.Cos(angle); 

        transform.position = center + new Vector2(xOffset, yOffset) * radius; 
    }

    public void TakeHit()
    {
        Destroy(gameObject);
    }
}
