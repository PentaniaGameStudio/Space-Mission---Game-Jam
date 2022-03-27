using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ScoreCounter : ObjectController
{
    private float Score;
    private float ActualScore;

    protected override void Update()
    {
        base.Update();
        ActualScore = (-transform.position.y)*200f;

        if (transform.position.y < -100f) { Score += ActualScore; ActualScore = 0; transform.position = new Vector3(0, 0, 0); }
    }

    public float GetScore()
    {
        return Score+ActualScore;
    }

}
