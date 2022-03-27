using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public abstract class ObjectController : MonoBehaviour 
{
    //Vitesse = (Timer(Kerozene) + Amélioration 1&2 + 
    [SerializeField] protected float speed = 0f;


    protected virtual void Update()
    {
        speed = gmIns.speedStruct.speed;
        transform.Translate(Vector3.down/3 * speed * Time.deltaTime);
    }
}
