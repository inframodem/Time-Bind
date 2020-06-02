using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using System.Linq.Expressions;
using UnityEngine.Analytics;

public class LevelController : MonoBehaviour
{
    public int[] inventory = new int[8];
    public float refresh = 2.0f;
    public float refreshmax = 2.0f;
    public GameController gc;
    public RawImage testobj;
    public GameObject[] portals = new GameObject[4];
    public LevelData[] currsaves = new LevelData[2];
    public InventoryController invc;
    public bool preventrepeat = false;
    public bool[] playerWin = new bool[2];
    
    
    // Start is called before the first frame update
    //sets saved data as new data
    public virtual void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        //currsaves[0] = new LevelData();
        //SendSave(1, new LevelData());
        //currsaves[1] = new LevelData();
        //SendSave(2, new LevelData());
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //cooldown between portal checks
        refresh -= Time.deltaTime;
        if (refresh <= 0f)
        {
                UpdatePortals();
            refresh = refreshmax;
        }
        if(playerWin[0] && playerWin[1])
        {
            gc.LevelTransition();
        }
    }
    //general get save data method from database method
    public void GetSave(int who)
    {
        string Levelname = gc.currLevel.ToString();
        RestClient.Get<LevelData>("https://time-bind.firebaseio.com/TimeBind/" + gc.key + "/" + Levelname + "/" + "Player" + who + ".json").Then(reponse =>
        {
            currsaves[who - 1] = reponse;
        });  
    }
    //sends leveldata to database
    public void SendSave(int who,LevelData send)
    {
        string Levelname = gc.currLevel.ToString();
        RestClient.Put("https://time-bind.firebaseio.com/TimeBind/" + gc.key + "/" + Levelname + "/" + "Player" + who + ".json", send);
    }
    public virtual void UpdatePortals()
    {
        //gets player data from database
        string Levelname = gc.currLevel.ToString();
        RestClient.Get<LevelData>("https://time-bind.firebaseio.com/TimeBind/" + gc.key + "/" + Levelname + "/" + "Player" + ((int)gc.playerType + 1) + ".json").Then(response =>
        {
            //having all this could in this then section makes sure all of this is executed in order
            currsaves[(int)gc.playerType] = response;

            //if the flag is set look through the portal list to see if a change has happened
            if (currsaves[(int)gc.playerType].getItem(0) == 1)
            {
                if (currsaves[(int)gc.playerType].getItem(1) == 1)
                {
                    gc.DeathTrigger();
                    currsaves[(int)gc.playerType].setItem(1, 0);
                }
                else if (currsaves[(int)gc.playerType].getItem(2) == 1)
                {
                    int who = 2;
                    Debug.Log("test");
                    switch ((int)gc.playerType + 1)
                    {
                        case 1:
                            who = 2;
                            break;
                        case 2:
                            who = 1;
                            break;
                    }
                    playerWin[who - 1] = true;
                    currsaves[(int)gc.playerType].setItem(2, 0);
                }

                else
                {
                    //if any portal in portal list has an item value greater then 1 generate the item at the portal with the same id - 1
                    for (int i = 3; i < currsaves[(int)gc.playerType].getListLength(); i++)
                    {
                        if (currsaves[(int)gc.playerType].getItem(i) > 1)
                        {

                            int item = currsaves[(int)gc.playerType].getItem(i);
                            PortalScript portal = portals[i - 3].GetComponent<PortalScript>();
                            portal.generateItem(currsaves[(int)gc.playerType].getItem(i) - 2);
                            currsaves[(int)gc.playerType].setItem(i, 0);
                        }
                        else if (currsaves[(int)gc.playerType].getItem(i) == 1)
                        {

                            int item = currsaves[(int)gc.playerType].getItem(i);
                            SwitchPortal portal = portals[i - 3].GetComponent<SwitchPortal>();
                            portal.indieToggleSwitch();
                            currsaves[(int)gc.playerType].setItem(i, 0);
                        }
                    }
                }
                //clears the flags and sends the new save data to the database to be stored
                currsaves[(int)gc.playerType].setItem(0, 0);
                SendSave((int)gc.playerType + 1, currsaves[(int)gc.playerType]);
                preventrepeat = false;
            }
        }).Catch(ex => 
        {
            currsaves[(int)gc.playerType] = new LevelData();
            SendSave((int)gc.playerType + 1, new LevelData());
            });
    }
    //main method for sending item to other player
    //takes a portal number and item number and updates other players save
    //returns a bool based on if the sending was successful
    public virtual void alterother(int portal, int invslot)
    {
        //determine what the other player is
        int who = 2;
        switch((int)gc.playerType + 1)
        {
            case 1:
                who = 2;
                break;
            case 2:
                who = 1;
                break;
        }
        
        //gets current level data to determine if sending is safe
        string Levelname = gc.currLevel.ToString();
        RestClient.Get<LevelData>("https://time-bind.firebaseio.com/TimeBind/" + gc.key + "/" + Levelname + "/" + "Player" + who + ".json").Then(reponse =>
        {

            LevelData send = reponse;
            if (send.getItem(0) <= 0)
            {
                //sets flag and updates item in portal slot
                send.setItem(3 + portal, inventory[invslot]);
                send.setItem(0, 1);
                SendSave(who, send);
                invc.updateslot(invslot, 0);
                inventory[invslot] = 0;
            }
        });
        
    }
    //adds item to inventory array and returns false if a slot couldn't be found 
    public virtual bool addtoInventory(int item)
    {
        bool filledslot = false;
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == 0 && filledslot == false)
            {
                inventory[i] = item;
                invc.updateslot(i, item);
                filledslot = true;
                break;
            }
        }
        return filledslot;
    }
    
    public virtual bool UseItemInInventory(int item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == item)
            {
                inventory[i] = 0;
                invc.updateslot(i, 0);
                return true;
            }
        }
        return false;
    }
    public virtual void ActivateWin()
    {
        playerWin[(int)gc.playerType] = true;
        LevelData send = new LevelData();
        send.setItem(0, 1);
        send.setItem(2, 1);
        int who = 2;
        switch ((int)gc.playerType + 1)
        {
            case 1:
                who = 2;
                break;
            case 2:
                who = 1;
                break;
        }
        SendSave(who, send);
    }
    public virtual void SendCrates(int portal,int cratetype)
    {
        playerWin[(int)gc.playerType] = true;
        LevelData send = new LevelData();
        send.setItem(0, 1);
        send.setItem(portal + 3, cratetype);
        int who = 2;
        switch ((int)gc.playerType + 1)
        {
            case 1:
                who = 2;
                break;
            case 2:
                who = 1;
                break;
        }
        SendSave(who, send);
    }

    public virtual void toggleswitch(int portal, bool mode)
    {
        //determine what the other player is
        int who = 2;
        switch ((int)gc.playerType + 1)
        {
            case 1:
                who = 2;
                break;
            case 2:
                who = 1;
                break;
        }
        int tog = 0;
        switch (mode)
        {
            case false:
                tog = 0;
                break;
            case true:
                tog = 1;
                break;
        }
        //sets flag and updates item in portal slot
        LevelData send = new LevelData();
        send.setItem(0, 1);
        send.setItem(portal + 3, tog);
        SendSave(who, send);
    }
}
