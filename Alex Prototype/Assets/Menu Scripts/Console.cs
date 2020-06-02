using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Console : MonoBehaviour
{
    public Text inputText;
    public GameController gc;
    public bool isActive = false;
    public GameObject con;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)){
            isActive = !isActive;
            con.SetActive(isActive);
        }
    }
    
    public void getCommand()
    {
        string[] words = inputText.text.Split();
        if (words.Length > 0)
        {
            switch (words[0])
            {
                case "nextlevel":
                    gc.LevelTransition();
                    break;
                case "loadlevel":
                    int i;
                    if (Int32.TryParse(words[1], out i))
                    {
                        gc.LoadNewLevel(i);
                    }
                    break;
            }
        }
    }
}
