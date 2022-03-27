using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StructUtils
{
    public static GameManager.SpeedStruct SpeedStructInitialize(GameManager.SpeedStruct speedStruct)
    {
        speedStruct.actualLevel = 1;
        speedStruct.difficultyLevel = 1;
        speedStruct.motorLevel = 1;
        speedStruct.keroseneLevel = 1;
        speedStruct.spatioPortLevel = 1;
        speedStruct.speed = 0;
        speedStruct.isSpeedUp = false;
        return speedStruct;
    }
    public static GameManager.ObstaclesStruct ObstacleStructInitialize(GameManager.ObstaclesStruct obsStruct)
    {
        obsStruct.difficultyLevel = 1;
        return obsStruct;
    }
    public static GameManager.BonusStruct BonusStructInitialize(GameManager.BonusStruct bonusStruct)
    {
        bonusStruct.bonus_list = new GameObject[15];
        for (int i = 0; i < 5; i++)
        {
            GameObject actual = GameManager.Instantiate(bonusStruct.bonus_type[0], bonusStruct.bonus_folder.transform);
            bonusStruct.bonus_list[i] = actual;
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject actual = GameManager.Instantiate(bonusStruct.bonus_type[1], bonusStruct.bonus_folder.transform);
            bonusStruct.bonus_list[10+i] = actual;
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject actual = GameManager.Instantiate(bonusStruct.bonus_type[2], bonusStruct.bonus_folder.transform);
            bonusStruct.bonus_list[20+i] = actual;
        }

        foreach(GameObject actual in bonusStruct.bonus_list)
        { actual.SetActive(false); }

        return bonusStruct;
    }
}
