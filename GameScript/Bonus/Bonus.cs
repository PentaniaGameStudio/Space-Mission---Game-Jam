using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public abstract class Bonus : ObjectController
{
    protected override void Update()
    {
            speed = gmIns.speedStruct.speed;
            transform.Translate(Vector3.down / 5 * speed * Time.deltaTime);
        if (transform.position.y < -5f) this.gameObject.SetActive(false); 
    }

    public void SetPosition(Vector3 pos)
    { transform.position = pos; }
}
