using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum PlayerType { Player1, Player2}
    public enum LevelList { Level1,Level2,Level3,Level4}
    public LevelList currLevel;
    public PlayerType playerType;
    public string key;
    void Awake()
    {
        //don't destroy on load
        DontDestroyOnLoad(this);
        //if it already exists destroy
        if (GameObject.Find(gameObject.name)
                 && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }
    // Start is called before the first frame update
    //when starting the game
    //set key for the session and determine which player it is
    public void StartOne(string newKey)
    {
        if (!string.IsNullOrEmpty(newKey))
        {
            key = newKey;
            playerType = PlayerType.Player1;
            currLevel = LevelList.Level1;
            SceneManager.LoadScene("Player1Level1");
        }
    }
    public void StartTwo(string newKey)
    {
        if (!string.IsNullOrEmpty(newKey))
        {
            key = newKey;
            playerType = PlayerType.Player2;
            currLevel = LevelList.Level1;
            SceneManager.LoadScene("Player2Level1");
        }
        
    }

}
