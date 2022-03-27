using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.gmIns.Bonus(1f, "life");
    }
}
