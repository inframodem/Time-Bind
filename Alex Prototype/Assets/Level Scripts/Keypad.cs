using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    string number;
    public CodeDoor currDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendInput(string number)
    {
        currDoor.CheckDoor(number);
        currDoor = null;
        gameObject.SetActive(false);
    }
    public void ExitPad()
    {
        currDoor = null;
        gameObject.SetActive(false);
    }
}
