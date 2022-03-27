using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerrican : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.gmIns.Bonus(2f, "kero");
    }
}
