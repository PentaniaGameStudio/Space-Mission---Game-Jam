using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;
using static VariableNameUtils;

public static class StructUtils
{
    public static GameManager.SpeedStruct SpeedStructInitialize(GameManager.SpeedStruct speedStruct)
    {
        speedStruct.actualLevel = 1;
        speedStruct.difficultyLevel = saveIns.Load<int>(1, savedDi); ;
        speedStruct.motorLevel = 1;
        speedStruct.keroseneLevel = 1;
        speedStruct.spatioPortLevel = 1;
        speedStruct.speed = 0;
        speedStruct.isSpeedUp = false;
        return speedStruct;
    }
    public static GameManager.ObstaclesStruct ObstacleStructInitialize(GameManager.ObstaclesStruct obsStruct)
    {
        obsStruct.difficultyLevel = saveIns.Load<int>(1, savedDi);


        obsStruct.obs_list = new GameObject[10];
        for (int i = 0; i < 5; i++)
        {
            GameObject actual = GameManager.Instantiate(obsStruct.obs_type[0], obsStruct.obs_folder.transform);
            obsStruct.obs_list[i] = actual;
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject actual = GameManager.Instantiate(obsStruct.obs_type[1], obsStruct.obs_folder.transform);
            obsStruct.obs_list[5 + i] = actual;
        }

        foreach (GameObject actual in obsStruct.obs_list)
        { actual.SetActive(false); }

        return obsStruct;
    }
    public static GameManager.BonusStruct BonusStructInitialize(GameManager.BonusStruct bonusStruct)
    {
        bonusStruct.bonus_list = new GameObject[10];
        for (int i = 0; i < 3; i++)
        {
            GameObject actual = GameManager.Instantiate(bonusStruct.bonus_type[0], bonusStruct.bonus_folder.transform);
            bonusStruct.bonus_list[i] = actual;
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject actual = GameManager.Instantiate(bonusStruct.bonus_type[1], bonusStruct.bonus_folder.transform);
            bonusStruct.bonus_list[3+i] = actual;
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject actual = GameManager.Instantiate(bonusStruct.bonus_type[2], bonusStruct.bonus_folder.transform);
            bonusStruct.bonus_list[8+i] = actual;
        }

        foreach(GameObject actual in bonusStruct.bonus_list)
        { actual.SetActive(false); }

        return bonusStruct;
    }
}
