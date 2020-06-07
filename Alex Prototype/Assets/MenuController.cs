using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public int menumode = 1;
    public GameObject mainmenu;
    public GameObject playmenu;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (menumode)
        {
            case 1:
                playmenu.SetActive(false);
                mainmenu.SetActive(true);
                break;
            case 2:
                mainmenu.SetActive(false);
                playmenu.SetActive(true);
                break;
        }
    }
    public void activateplay()
    {
        menumode = 2;
    }
    public void activatemain()
    {
        menumode = 1;
    }
}
