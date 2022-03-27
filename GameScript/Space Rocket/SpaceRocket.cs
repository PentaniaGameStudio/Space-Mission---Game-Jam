using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class SpaceRocket : MonoBehaviour
{
    public static SpaceRocket rocketIns;
    [SerializeField] private MotorStat motor = new MotorStat();
    [SerializeField] private SpatioportStat spatioPort = new SpatioportStat();
    [SerializeField] private KeroseneStat kerosene = new KeroseneStat();

    [SerializeField] public float keroseneValue{get; private set;}
[SerializeField] private float rocketMaxLife = 5f;
    [SerializeField] public float rocketActualLife {get; private set;}

    private void Awake()
    {
        if (rocketIns == null) rocketIns = this;
        else Destroy(this);
        rocketActualLife = 5f;
        keroseneValue = 0.5f;
    }
    private void Start()
    {
        keroseneValue += gmIns.speedStruct.keroseneLevel * 0.5f;
    }
    public void SetLife(float value)
    {
        rocketActualLife += value;
    }
    public void SetKero(float value)
    {
        keroseneValue += value;
    }

}
