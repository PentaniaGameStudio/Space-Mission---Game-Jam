using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Alien : Obstacles
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gmIns.speedStruct.speed /= 2;
            gmIns.GetBonus(-1, Bonus.BonusType.Life);
            this.gameObject.SetActive(false);
        }
    }

}
