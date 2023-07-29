using JetBrains.Annotations;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManager : MonoBehaviour
{

    static MainManager instance = null;
    public GameObject playerCharacter;
    string savePath;
    
    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this; 
        DontDestroyOnLoad(this);
        savePath = Application.persistentDataPath + "/savefile.json";
    }
    public void SelectCharacter(GameObject character)
    {
        playerCharacter = character;
    }
    [System.Serializable]
    class SaveData
    {
        public GameObject playerCharacter;
    }
    void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.playerCharacter = playerCharacter;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }
    void LoadPlayerInfo()
    {

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerCharacter = data.playerCharacter;
        }
    }
}
