using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LevelController lc;
    public int item;
    public bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");
       if(collision.gameObject.name == "Player")
        {
            if (lc.UseItemInInventory(item))
            {
                GetComponent<AudioSource>().Play();
                open = true;
            }
        }
    }
    void FixedUpdate()
    {
        if (open && !GetComponent<AudioSource>().isPlaying)
            Destroy(gameObject);
    }
}
