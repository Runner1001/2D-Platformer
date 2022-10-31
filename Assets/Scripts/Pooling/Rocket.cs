using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxLifeTime;
    [SerializeField] private int damage = 1;

    private float lifeTime;
    private Vector2 direction;

    void OnEnable()
    {
        lifeTime = maxLifeTime;
        direction = new Vector2(-1, 0);
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        transform.Translate(direction * speed * Time.deltaTime);

        if(lifeTime < 0)
        {
            RocketPool.Instance.ReturnToPool(this);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if(player != null)
        {
            player.TakeHit(damage);
            RocketPool.Instance.ReturnToPool(this);
        }

        RocketPool.Instance.ReturnToPool(this);
    }
}
