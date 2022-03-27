using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerrican : Bonus
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") GameManager.gmIns.GetBonus(0.2f*SpaceRocket.rocketIns.bonusmultiplier, BonusType.Kerosene);
        base.OnTriggerEnter2D(other);
    }
}
