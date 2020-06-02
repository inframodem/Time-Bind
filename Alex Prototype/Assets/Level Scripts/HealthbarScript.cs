using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarScript : MonoBehaviour
{
    public GameController gc;
    public GameObject[] healthpips = new GameObject[10];
        // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        gc.UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthbar(int newhealth)
    {
        for(int i = 0; i < healthpips.Length; i++)
        {
            newhealth--;
            if(newhealth >= 0)
            {
                healthpips[i].SetActive(true);
            }
            else
            {
                healthpips[i].SetActive(false);
            }
        }
    }
}
