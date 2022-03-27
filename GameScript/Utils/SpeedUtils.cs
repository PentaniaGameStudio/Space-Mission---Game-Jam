using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public static class SpeedUtils
{
    public static float SpeedCalculator(GameManager.SpeedStruct speedStruct)
    {
        float motor = speedStruct.motorLevel;

        if (gmIns.planetReached) speedStruct.speed = SpeedUtils.PlanetReached(speedStruct);
        else if (speedStruct.isSpeedUp && speedStruct.speed < GameManager.gmIns.maxSpeed)
        {
            speedStruct.speed += 0.5f * (motor * 0.5f) * 0.1f;
        }
        else
        {
            speedStruct.speed -= (Time.deltaTime * 0.05f + (speedStruct.speed * 0.0003f)) / (motor * 0.5f);
        }
        speedStruct.speed = NoNegative(speedStruct.speed);
        return speedStruct.speed;
    }

    public static float PlanetReached(GameManager.SpeedStruct speedStruct)
    {
        
        speedStruct.speed -= speedStruct.speed * 1.5f * Time.deltaTime ;
        speedStruct.speed = NoNegative(speedStruct.speed);


        return speedStruct.speed;
    }

    public static float StartingSpeed(GameManager.SpeedStruct speedStruct)
    {
        float spatioPort = speedStruct.spatioPortLevel;
        float motor = speedStruct.motorLevel;
        speedStruct.speed *= 1.01f + motor * 0.03f + spatioPort * 0.05f;
        speedStruct.speed = LimitSpeed(speedStruct.speed);
        return speedStruct.speed;
    }

    public static float LimitSpeed(float speed)
    {
        if (speed > 50f) speed = 50f;
        if (speed < 0f) speed = 0f;
        return speed;
    }
    public static float NoNegative(float speed)
    {
        if (speed > 50f) speed = 50f;
        if (speed < 0f) speed = 0f;
        return speed;
    }





}
