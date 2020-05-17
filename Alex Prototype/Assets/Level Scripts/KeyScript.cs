using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int keyID;
    public LevelController lc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject intermed = GameObject.Find("LevelController");
        lc = intermed.GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collider is player add the key id + 2 for the values none and set to the add to inventory method
        //if it worked delete key
        if(collision.gameObject.name == "Player")
        {
            bool addsuccess;
            addsuccess = lc.addtoInventory(keyID + 2);
            if(addsuccess)
                Destroy(gameObject);
        }
    }
}
