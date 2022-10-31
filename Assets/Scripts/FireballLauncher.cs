using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] private Fireball fireballPrefab; 
    [SerializeField] private float fireRate; 

    private Player player; 
    private string fireButton; 
    private float fireDelay; 

    void Start()
    {
        player = GetComponent<Player>();
        fireButton = $"P{player.PlayerNumber}Fire1";
    }

    void Update()
    {
        if (Input.GetButtonDown(fireButton) && Time.time >= fireDelay) 
        {
            Fireball fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity); 
            fireball.Direction = player.Direction; 
            fireDelay = Time.time + fireRate;
        }
    }
}
