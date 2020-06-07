
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPortal : MonoBehaviour
{
    public LevelController lc;
    public int portal = 4;
    public GameObject[] doors = new GameObject[1];
    public GameObject prompt;
    public SpriteRenderer switchSprite;
    public bool inTrigger = false;
    public bool isASwitch = false;
    public bool switchmode;
    public bool attached = true;
    public float cool = 2.5f;
    public float maxcool = 2.5f;
    public bool isaportal = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cool -= Time.deltaTime;
        if (inTrigger && cool <= 0f && isASwitch)
        {
            Debug.Log("test1");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("test2");
                if (attached)
                    toggleswitch();
                else
                    indieToggleSwitch();
                cool = maxcool;
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            prompt.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
        inTrigger = false;
    }

    public void toggleswitch()
    {
        switchmode = !switchmode;
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(!doors[i].activeSelf);
        }
        switchSprite.flipY = switchmode;
        if(isaportal)
            lc.toggleswitch(portal, true);

    }
    public void indieToggleSwitch()
    {
        switchmode = !switchmode;
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(!doors[i].activeSelf);
        }
        switchSprite.flipY = switchmode;
        

    }
}
