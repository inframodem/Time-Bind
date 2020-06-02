
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public int portalID;
    public GameObject[] prefabs = new GameObject[15];
    public LevelController controller;
    public bool isEndPoint;
    public InventoryController invc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void SendItem(int i)
    {
        if (controller.inventory[i] > 0)
        {

            //activate alter other with the inventory slot using the portal id
            controller.alterother(portalID, i);
            //set inventory item to none
        }

    }
    public void generateItem(int item)
    {
        if (isEndPoint)
        {
            //generate item sent through the portal
            Instantiate(prefabs[item], transform.position, transform.rotation);
        }
    }

    //set if  its the player entering the portal
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player" && !isEndPoint)
        {
            //set inventory controller's current portal to this portal
            invc.currentportal = this;
        }
        if (col.tag == "draggable" && !isEndPoint)
        {
            RockMovement boxS = col.GetComponent<RockMovement>();
            //set inventory controller's current portal to this portal
            controller.SendCrates(portalID, boxS.cratetype);
            Destroy(col.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            //set inventory controllers current portal to null if exiting trigger
            invc.currentportal = null;

        }
        if (col.tag == "draggable" && !isEndPoint)
        {
            //set inventory controller's current portal to this portal
            invc.currentportal = this;
        }
    }
}
