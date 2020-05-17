using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    public bool isPlayer1;
    public Text keyinput;
    public GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
    //basic starting button that sends key string to game controllor to be set
    public void buttonpress()
    {
        if (isPlayer1) { gc.StartOne(keyinput.text); }
        else
            gc.StartTwo(keyinput.text);
    }
}
