using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;
using static ChooseDifficulty;
using static VariableNameUtils;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager mmmIns;
    [SerializeField] private int levelToLaunch;
    [SerializeField] private int levelDifficulty;

    private void Awake()
    {
        mmmIns = this;
    }

    public void DifficultyButton()
    {
        levelDifficulty = diffIns.ClickedDifficulty();
    }

    public void StartButton()
    {
        levelDifficulty = saveIns.Load<int>(1, actualDi);
        saveIns.OverwriteSave();
        saveIns.Save<int>(levelDifficulty, savedDi);
        GameStart(1);
    }

    public void LoadButton()
    {
        levelToLaunch = saveIns.Load<int>(1, saveLevel);
        GameStart(levelToLaunch);

    }

    public void GameStart(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
