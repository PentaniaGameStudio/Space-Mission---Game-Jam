using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public abstract class Bonus : ObjectController
{
    public enum BonusType
    {
        Life,
        Kerosene,
        Coin

    }

    protected GameObject particle;

    protected override void Update()
    {
            speed = gmIns.speedStruct.speed;
            transform.Translate(Vector3.down / 8 * speed * Time.deltaTime);
        if (transform.position.y < -12f) this.gameObject.SetActive(false); 
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag =="Player") this.gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 pos)
    {transform.position = pos;}
}
