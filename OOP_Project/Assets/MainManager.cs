using JetBrains.Annotations;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManager : MonoBehaviour
{
    public GameObject[] characters;
    static MainManager instance = null;
    public GameObject playerCharacter { get; private set; }
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
    public void SelectCharacter(int characterIndex)
    {
        playerCharacter = characters[characterIndex];
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
