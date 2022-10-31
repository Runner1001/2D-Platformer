using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : HittableBox
{
    [SerializeField] private int totalCoins = 5; 

    private int coinsLeft;

    protected override bool canUse => coinsLeft > 0; 

    void Start()
    {
        coinsLeft = totalCoins; 
    }

    protected override void Use()
    {
        if (coinsLeft > 0)
        {
            coinsLeft--; 
            Coin.Coins++;
        }
    }
}