using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    MainManager manager;
    void Start()
    {
        manager = FindObjectOfType<MainManager>();
        Instantiate(manager.playerCharacter,Vector3.up*2,Quaternion.identity);
    }

}
