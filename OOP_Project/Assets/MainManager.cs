using JetBrains.Annotations;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{
    public GameObject[] characters;
    static MainManager instance = null;
    public GameObject playerCharacter { get; private set; }
    public int playerCharacterIndex { get; private set; }
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

        LoadPlayerInfo();
    }
    public void SelectCharacter(int characterIndex)
    {
        playerCharacter = characters[characterIndex];
        playerCharacterIndex = characterIndex;
    }
    [System.Serializable]
    class SaveData
    {
        public GameObject playerCharacter;
        public int playerCharacterIndex;
    }
    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.playerCharacter = playerCharacter;
        data.playerCharacterIndex = playerCharacterIndex;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }
    public void LoadPlayerInfo()
    {

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerCharacter = data.playerCharacter;
            playerCharacterIndex = data.playerCharacterIndex;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
