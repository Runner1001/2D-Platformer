using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private float fireRate;

    private float fireDelay;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(fireDelay < Time.time)
        {
            var rocket = RocketPool.Instance.Get();
            rocket.gameObject.SetActive(true);
            rocket.transform.position = transform.position;

            fireDelay = Time.time + fireRate;
        }
    }
}
