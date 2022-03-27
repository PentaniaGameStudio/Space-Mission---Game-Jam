using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : Bonus
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") GameManager.gmIns.GetBonus(1f, BonusType.Life);
        base.OnTriggerEnter2D(other);
    }
}
