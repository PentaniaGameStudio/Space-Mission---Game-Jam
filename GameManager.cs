using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static SaveManager;
using static VariableNameUtils;
using UnityEngine.UI;
using static SpaceRocket;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmIns;
    [SerializeField] private int difficultyLevel;
    [SerializeField] public SpeedStruct speedStruct = new SpeedStruct();
    [SerializeField] private ObstaclesStruct obsStruct = new ObstaclesStruct();
    [SerializeField] private BonusStruct bonusStruct = new BonusStruct();
    [SerializeField] private ScoreCounter scoreCounter;
    public float maxSpeed = 50f;
    public float score;
    public int money;
    
    public bool planetReached;
    public bool gameStarted { get;private set; }
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
        public GameObject[] obs_list;
        public GameObject[] obs_type;
        public GameObject obs_folder;
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
    }

    public void Start()
    {
        speedStruct = saveIns.Load<SpeedStruct>(StructUtils.SpeedStructInitialize(speedStruct), vn_speedStruct);
        obsStruct = StructUtils.ObstacleStructInitialize(obsStruct);
        bonusStruct = StructUtils.BonusStructInitialize(bonusStruct);
    }

    private void Update()
    {
        SetSpeed();
        score = scoreCounter.GetScore() * 8f;
        CanvasManager.cmIns.TextManager(speedStruct, score);
        if (planetReached) Finished();
        if (speedStruct.speed <= 0 && rocketIns.GetKero() <= 0) GameOver();
    }

    public void GetBonus(float value, Bonus.BonusType type)
    {
        if (type == Bonus.BonusType.Life) SpaceRocket.rocketIns.SetLife(value);
        else if (type == Bonus.BonusType.Kerosene) rocketIns.SetKero(value);
        else if (type == Bonus.BonusType.Coin) money += (int)value;
    }


    private void SetSpeed()
    {
        if(gameStarted)
        {
            if (Input.GetButton("Fire1") && rocketIns.GetKero() >= 0f && speedStruct.speed < maxSpeed && planetReached == false) 
            {
                speedStruct.isSpeedUp = true;
                rocketIns.SetKero(-0.3f * Time.deltaTime);
            } else speedStruct.isSpeedUp = false;

            speedStruct.speed = SpeedUtils.SpeedCalculator(speedStruct);
        }
    }

    public void Fire()
    {
        speedStruct.speed = 8f * speedStruct.spatioPortLevel * 1.2f;
        StartCoroutine(FireCoroutine());
        StartCoroutine(BonusCoroutine());
        StartCoroutine(ObsCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        float time = 2f * speedStruct.spatioPortLevel * 1.1f;
        for (float f = 0; f < time / 2; f += 0.1f)
        {
            speedStruct.speed = SpeedUtils.StartingSpeed(speedStruct);
            yield return new WaitForSeconds(0.1f);
        }
        for (float f = 0; f < time / 2; f += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
        }
        gameStarted = true;
        yield return null;
    }
    IEnumerator BonusCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(1, 3);
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            Vector3 pos = new Vector3(Random.Range(-2.5f, 3f), 0, -0.5f);
            bonusStruct.bonus_list[i * random].GetComponent<Bonus>().SetPosition(pos);
            bonusStruct.bonus_list[i * random].SetActive(true);
        }
        StartCoroutine(BonusCoroutine());
    }
    IEnumerator ObsCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(1, 3);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            Vector3 pos = new Vector3(Random.Range(-2.5f, 3f), 0, -0.4f);
            obsStruct.obs_list[i * random].GetComponent<Obstacles>().SetPosition(pos);
            obsStruct.obs_list[i * random].SetActive(true);
        }
        StartCoroutine(ObsCoroutine());
    }

    private void Finished()
    {
        saveIns.Save<SpeedStruct>(speedStruct, vn_speedStruct);
    }

    private void GameOver()
    {
        saveIns.Save<SpeedStruct>(speedStruct, vn_speedStruct);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
