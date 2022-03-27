using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Bonus
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.gmIns.GetBonus(10f, BonusType.Coin);
        base.OnTriggerEnter2D(other);
    }
}
