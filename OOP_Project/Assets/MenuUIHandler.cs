using JetBrains.Annotations;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject[] characters;
    public MainManager mainManager;
    
    private void Start()
    {
        if (mainManager = null)
        {
            FindObjectOfType<MainManager>();
        }
    }
    public void PlaySquire()
    {
        mainManager.SelectCharacter(characters[0]);
        SceneManager.LoadScene(1);
    }
    public void PlayTank()
    {
        mainManager.SelectCharacter(characters[1]);
        SceneManager.LoadScene(1);
    }
    public void PlayRogue()
    {
        mainManager.SelectCharacter(characters[2]);
        SceneManager.LoadScene(1);

    }
}

