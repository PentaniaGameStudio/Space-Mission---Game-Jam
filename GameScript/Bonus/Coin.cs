using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.gmIns.Bonus(10f, "coin");
    }
}
