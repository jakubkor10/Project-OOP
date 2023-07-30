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
    public Button[] buttons = new Button[3];
    Image[] buttonImages = new Image[3];
    Color selectionHighlightColor = Color.green;
    Color defaultButtonColor = Color.white;
    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonImages[i] = buttons[i].GetComponent<Image>();
        }

        mainManager = FindObjectOfType<MainManager>();

        if (mainManager.playerCharacter != null)
        {
            HighlightSelection();
        }
    }
    public void Play()
    {
        mainManager.Play();
    }
    public void Exit()
    {
        mainManager.SavePlayerInfo();
        mainManager.Exit();
    }
    
    public void SelectRogue()
    {
        mainManager.SelectCharacter(0);
        HighlightSelection();
    }
    public void SelectTank()
    {
        mainManager.SelectCharacter(1);
        HighlightSelection();
    }
    public void SelectSquire()
    {
        mainManager.SelectCharacter(2);
        HighlightSelection();

    }
    public void HighlightSelection()
    {
        foreach (var image in buttonImages)
        {
            image.color = defaultButtonColor;
        }
        buttonImages[mainManager.playerCharacterIndex].color = selectionHighlightColor;
    }
}

