using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LevelController lc;
    public int item;
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
                Destroy(gameObject);
            }
        }
    }
    void FixedUpdate()
    { 
    }
}
