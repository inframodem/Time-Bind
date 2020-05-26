using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDoor : MonoBehaviour
{
    public LevelController lc;
    public int[] item = new int[3];
    public bool[] aquired = new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");
       if(collision.gameObject.name == "Player")
        {
            for(int i = 0; i < item.Length; i++) {
                if (!aquired[i])
                    aquired[i] = lc.UseItemInInventory(item[i]);
                
            }
            bool totalaquired = true;
            for (int i = 0; i < item.Length; i++)
            {
                if (!aquired[i])
                    totalaquired = false;
            }

            if (totalaquired)
            {
                Destroy(gameObject);
            }
        }
    }
    void FixedUpdate()
    { 
    }
}
