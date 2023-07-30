using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    MainManager manager;
    void Start()
    {
        manager = FindObjectOfType<MainManager>();
        Instantiate(manager.playerCharacter,Vector3.up*2,Quaternion.identity);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }
    void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
