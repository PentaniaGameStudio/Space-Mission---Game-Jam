using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static SaveManager;
using static VariableNameUtils;
using UnityEngine.UI;
using System;
using static SpaceRocket;

public class GameManager : MonoBehaviour
{
    public static GameManager gmIns;
    [SerializeField] private int difficultyLevel;
    [SerializeField] public SpeedStruct speedStruct = new SpeedStruct();
    [SerializeField] private ObstaclesStruct obsStruct = new ObstaclesStruct();
    [SerializeField] private BonusStruct bonusStruct = new BonusStruct();
    [SerializeField] private ScoreCounter scoreCounter;
    public float maxSpeed = 30f;
    public float score;
    public int money;
    
    public bool planetReached;
    private bool gameStarted = false;
    [System.Serializable]public struct SpeedStruct
    {
        public int actualLevel;
        public int difficultyLevel;
        public int motorLevel;
        public int spatioPortLevel;
        public int keroseneLevel;
        public float speed;
        public bool isSpeedUp;
    }

    [System.Serializable]
    public struct ObstaclesStruct
    {
        public int difficultyLevel;
    }

    [System.Serializable]
    public struct BonusStruct
    {
        public int difficultyLevel;
        public GameObject[] bonus_list;
        public GameObject[] bonus_type;
        public GameObject bonus_folder;
    }


    private void Awake()
    {
        if (gmIns == null) gmIns = this;
        else Destroy(this);
        speedStruct = StructUtils.SpeedStructInitialize(speedStruct);
        obsStruct = StructUtils.ObstacleStructInitialize(obsStruct);
        bonusStruct = StructUtils.BonusStructInitialize(bonusStruct);
    }

    public void Start()
    {
        difficultyLevel = saveIns.Load<int>(1, savedDi);
        speedStruct.difficultyLevel = difficultyLevel;
        obsStruct.difficultyLevel = difficultyLevel;
        
    }

    private void Update()
    {
        SetSpeed();
        score = scoreCounter.GetScore() * 8f;
        CanvasManager.cmIns.TextManager(speedStruct, score);
    }

    public void Bonus(float value, string type)
    {
        if (type == "life") SpaceRocket.rocketIns.SetLife(value);
        else if (type == "kero") rocketIns.SetKero(value);
        else if (type == "coin") money += (int)value;
    }


    private void SetSpeed()
    {
        if(gameStarted)
        {
            if (Input.GetButton("Fire1")/* && keroseneValue >= 0f*/ && speedStruct.speed < maxSpeed && planetReached == false) 
            {
                speedStruct.isSpeedUp = true;
                rocketIns.SetKero(0.3f * Time.deltaTime);
            } else speedStruct.isSpeedUp = false;

            speedStruct.speed = SpeedUtils.SpeedCalculator(speedStruct);
        }
    }

    public void Fire()
    {
        speedStruct.speed = 4f * speedStruct.spatioPortLevel * 1.2f;
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        float time = 2f * speedStruct.spatioPortLevel * 1.1f;
        for (float f = 0; f < time; f += 0.1f)
        {
            Debug.LogWarning("Coroutine En Cours");
            speedStruct.speed = SpeedUtils.StartingSpeed(speedStruct);
            yield return new WaitForSeconds(0.1f);
        }
        gameStarted = true;
        Debug.LogWarning("Coroutine Finie");
        yield return null;
    }
    IEnumerator BonusCoroutine()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0f,4f));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
