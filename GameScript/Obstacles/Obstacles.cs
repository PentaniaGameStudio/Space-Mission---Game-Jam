using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;


public abstract class Obstacles : ObjectController
{
    public virtual void SetRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-20, 20));
    }
    protected override void Update()
    {
        speed = gmIns.speedStruct.speed;
        transform.Translate(Vector3.down / 5 * speed * Time.deltaTime);
        if (transform.position.y < -12f) this.gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gmIns.speedStruct.speed /= 2;
            gmIns.GetBonus(-2, Bonus.BonusType.Life);
            this.gameObject.SetActive(false);
        }

    }
    public void SetPosition(Vector3 pos)
    { 
        transform.position = pos; 
        transform.eulerAngles = Vector3.zero;
        SetRotation();
    }

}
