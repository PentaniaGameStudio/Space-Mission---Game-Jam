using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class SpaceRocket : MonoBehaviour
{
    public static SpaceRocket rocketIns;
    [SerializeField] private MotorStat motor;
    [SerializeField] private SpatioportStat spatioPort;
    [SerializeField] private KeroseneStat kerosene;

    [SerializeField] private float keroseneValue;
    [SerializeField] private float keroseneActualMaxValue = 1f;
    [SerializeField] private float keroseneMaxValue = 1f;
    public float multiplier { get; private set; }
    public float bonusmultiplier { get; private set; }
    [SerializeField] private float rocketMaxLife = 5f;
    [SerializeField] private float rocketActualLife;

    private void Awake()
    {
        if (rocketIns == null) rocketIns = this;
        else Destroy(this);
        rocketActualLife = 5f;
        keroseneValue = 1f;
    }

    private void Start()
    {
        keroseneValue += gmIns.speedStruct.keroseneLevel * 0.5f;
    }

    private void Update()
    {
        Move();
        multiplier = keroseneMaxValue / keroseneActualMaxValue;
        bonusmultiplier = keroseneActualMaxValue / keroseneMaxValue;
    }
    private void Move()
    {
        if (gmIns.gameStarted)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;
            pos.y = transform.position.y;
            if (pos.x > 2.8) pos.x = 2.8f;
            if (pos.x < -2.8) pos.x = -2.8f;
            transform.position = pos;
        }
    }

    public void SetLife(float value)
    {
        rocketActualLife += value;
        if (rocketActualLife > rocketMaxLife) rocketActualLife = rocketMaxLife;
    }

    public void SetKero(float value)
    {
        value *= multiplier;
        keroseneValue += value;
        if (keroseneValue > keroseneMaxValue) keroseneValue = keroseneMaxValue;
    }

    public float GetLife()
    { return rocketActualLife; }

    public float GetKero()
    { return keroseneValue; }

}
