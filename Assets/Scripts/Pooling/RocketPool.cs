using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPool : MonoBehaviour
{
    [SerializeField] private Rocket rocketPrefab;

    private Queue<Rocket> rocketsPool = new Queue<Rocket>();

    public static RocketPool Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        GrowPool(30);
    }

    private void GrowPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var rocket = Instantiate(rocketPrefab, transform);
            rocket.gameObject.SetActive(false);
            rocketsPool.Enqueue(rocket);
        }
    }

    public Rocket Get()
    {
        if (rocketsPool.Count == 0)
            GrowPool(1);

        return rocketsPool.Dequeue();
    }

    public void ReturnToPool(Rocket rocket)
    {
        rocket.gameObject.SetActive(false);
        rocketsPool.Enqueue(rocket);
    }
}
