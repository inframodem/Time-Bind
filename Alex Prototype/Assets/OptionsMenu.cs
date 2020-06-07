using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public GameController gc;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
    public void ResetLevel()
    {
        gc.NaturalDeathTrigger();
    }
    public void quitapp()
    {
        Application.Quit();
    }
    public void closewindow()
    {
        menu.SetActive(false);
    }
}
