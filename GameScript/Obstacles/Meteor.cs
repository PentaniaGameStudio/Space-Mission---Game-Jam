using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Obstacles
{

    public override void SetRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-30, 30));
    }
}
