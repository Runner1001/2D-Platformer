using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : HittableBox 
{
    [SerializeField] private GameObject lifePickUpPrefab; 

    private bool used; 

    protected override bool canUse => !used;

    public void SpawnLife() 
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1, 0); 
        Instantiate(lifePickUpPrefab, newPos, Quaternion.identity); 
    }

    protected override void Use() 
    {
        used = true; 
    }
}