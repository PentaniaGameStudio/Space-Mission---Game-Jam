using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager saveIns;
    private string path;

    [System.Serializable]
    public class SaveData
    {
        //MainMenuSave//
        public int saveLevel = 0;
        public int actualDifficulty = 1;
        public int savedDifficulty = 1;
        public GameManager.SpeedStruct speedStruct;
        public GameManager.ObstaclesStruct obstaclesStruct;

        //GameplayReleatedSave//

    }
    public SaveData saveData = new SaveData();
    private FieldInfo dataToCheck;





    private void Awake()
    {
        if (saveIns == null) { saveIns = this; DontDestroyOnLoad(this); LoadPersistantData(); path = Application.dataPath + "/Save/Save.json"; }
        else Destroy(this);
    }

    private void OnApplicationQuit()
    {
        string json = JsonUtility.ToJson(saveData);
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        file.Directory.Create();
        File.WriteAllText(path, json);
    }

    private void LoadPersistantData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
    }

    public void OverwriteSave()
    {
        saveData = new SaveData();
    }

    public void Save<T>(T types, string variableName)
    {
        if (TryVariableName(variableName) == true)
        {
            dataToCheck = typeof(SaveManager.SaveData).GetField(variableName);
            if (dataToCheck.FieldType == typeof(T))
            {
                dataToCheck.SetValue(saveData, types);
            }
            else Debug.LogWarning("Type Error. Verify type please :)");
        }
        else Debug.LogWarning("Variable doesn't exist. Verify Name please :)");
    }

    public T Load<T>(T baseValue, string variableName)
    {
        if (TryVariableName(variableName) == true)
        {
            dataToCheck = typeof(SaveManager.SaveData).GetField(variableName);
            if (dataToCheck.FieldType == typeof(T))
            {
                if (dataToCheck != null)
                {
                    baseValue = (T)dataToCheck.GetValue(saveData);
                    return baseValue;
                }
            }
            else Debug.LogWarning("Type Error. Verify type please :)");
        }
        else Debug.LogWarning("Variable doesn't exist. Verify Name please :)");

        return baseValue;
    }

    private bool TryVariableName(string variableName)
    {
        bool result = false;
        foreach (FieldInfo field in typeof(SaveManager.SaveData).GetFields())
                {
                 if (variableName == field.Name){ result= true; break; }
                }
        return result;
    }
}
