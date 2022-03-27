using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VariableNameUtils;

public class ChooseDifficulty : MonoBehaviour
{
    public static ChooseDifficulty diffIns;
    private string[] difficultyLevel = new string[3] {"Easy","Normal","Hard"};
    [SerializeField] private Color[] difficultyColor = new Color[3];
    [SerializeField] private TMPro.TextMeshProUGUI[] difficultyButton;
    private int actualLevel = 1;

    private void Awake()
    {
        if (diffIns == null) diffIns = this;
        else Destroy(this);
    }

    private void Start()
    {
        SaveManager.saveIns.Load<int>(actualLevel, actualDi);
        difficultyButton[1].text = difficultyLevel[actualLevel];
        difficultyButton[0].faceColor = difficultyColor[actualLevel];
        difficultyButton[1].faceColor = difficultyColor[actualLevel];

    }

    public int ClickedDifficulty()
    { 
        actualLevel++;
        if (actualLevel >= difficultyLevel.Length) actualLevel = 0;
        difficultyButton[1].text = difficultyLevel[actualLevel];
        difficultyButton[0].faceColor = difficultyColor[actualLevel];
        difficultyButton[1].faceColor = difficultyColor[actualLevel];
        SaveManager.saveIns.Save<int>(actualLevel, actualDi);
        return actualLevel;
    }



}
