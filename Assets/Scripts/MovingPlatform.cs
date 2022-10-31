using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform endPos;
    [SerializeField] private float speed = 3;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPos.position, speed * Time.deltaTime);
    }
}
