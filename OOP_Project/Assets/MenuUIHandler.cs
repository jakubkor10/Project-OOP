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
    public MainManager mainManager;
    
    public void PlayRogue()
    {
        mainManager.SelectCharacter(0);
        SceneManager.LoadScene(1);
    }
    public void PlayTank()
    {
        mainManager.SelectCharacter(1);
        SceneManager.LoadScene(1);
    }
    public void PlaySquire()
    {
        mainManager.SelectCharacter(2);
        SceneManager.LoadScene(1);

    }
}

