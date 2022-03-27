using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static SaveManager;
using static VariableNameUtils;
using UnityEngine.UI;
using System;
using static SpaceRocket;
using static GameManager;

public class CanvasManager : MonoBehaviour
{

    public static CanvasManager cmIns;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI speedText;
    [SerializeField] private TMPro.TextMeshProUGUI funText;
    [SerializeField] private Image keroseneSlider;
    [SerializeField] private Image lifeSlider;


    private void Awake()
    {
        if (cmIns == null) cmIns = this;
        else Destroy(this);
    }

    public void Start()
    {
    }

    private void Update()
    {
        keroseneSlider.fillAmount = rocketIns.keroseneValue;

        lifeSlider.fillAmount = SpaceRocket.rocketIns.rocketActualLife / 5;
    }

    public void TextManager(GameManager.SpeedStruct speedStruct, float score)
    {
        scoreText.text = "Score : " + score.ToString("0");
        speedText.text = (speedStruct.speed * 800).ToString("0") + "km/sec";
        if (speedStruct.speed < 1) funText.text = "";
        else if (speedStruct.speed > 14) funText.text = "Lightspeed means nothing for you right ?";
        else if (speedStruct.speed > 6) funText.text = "Ooops forgot cofee on Earth ! U-turn ? ";
        else if (speedStruct.speed > 1) funText.text = "Yeah, That's fast. Like Really Fast. Yup.";
    }
}
