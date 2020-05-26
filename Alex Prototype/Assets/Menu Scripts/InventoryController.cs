using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public PortalScript currentportal;
    public Image[] images = new Image[8];
    public Sprite[] itemsprites = new Sprite[10];
    public LevelController lc;
    public float transfercooldown = 2.5f;
    public float transfercooldownmax = 2.5f;
    public bool transferready = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cooldown to prevent rapid sents in case other portal isn't ready
        transfercooldown -= Time.deltaTime;
        if(transfercooldown < 0)
        {
            transferready = true;
            transfercooldown = transfercooldownmax;
        }
    }
    //sends inventory slot item through portal if its not an endpoint or the item slot is zero
    public void sendthroughportal(int i)
    {
        if (currentportal != null && lc.inventory[i] != 0 && !currentportal.isEndPoint)
        {
            currentportal.SendItem(i);
        }
    }
    //updates inventory slot picture to new image
    public void updateslot(int i, int item)
    {
        Debug.Log("test2");
        switch (item)
        {
            case 0:
                images[i].sprite = null;
                images[i].color = new Vector4(1f,1f,1f,0f);
                break;
            case 2:
                images[i].sprite = itemsprites[1];
                images[i].color = Color.red;
                break;

            case 3:
                images[i].sprite = itemsprites[1];
                images[i].color = Color.blue;
                break;

            case 4:
                images[i].sprite = itemsprites[1];
                images[i].color = Color.yellow;
                break;
            case 7:
                images[i].sprite = itemsprites[2];
                images[i].color = Color.green;
                break;
            case 8:
                images[i].sprite = itemsprites[2];
                images[i].color = new Vector4(1f,0,1f,1f);
                break;
            case 9:
                images[i].sprite = itemsprites[2];
                images[i].color = Color.yellow;
                break;
        }
    }
    //Lot of methods for if inventory buttons are pressed
    //if the current portal isn't null and transfer cooldown has finished
    //if current portal isn't an end point
    //send the pressed inventory slot item through the portal and set the item to none
    public void Press0()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(0);

            }
        }
    }
    public void Press1()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(1);

            }
        }
    }
    public void Press2()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(2);

            }
        }
    }
    public void Press3()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(3);

            }
        }
    }
    public void Press4()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(4);

            }
        }
    }
    public void Press5()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(5);

            }
        }

    }
    public void Press6()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(6);

            }
        }
    }
    public void Press7()
    {
        if (currentportal != null && transferready)
        {
            if (!currentportal.isEndPoint)
            {
                transferready = false;
                sendthroughportal(7);

            }
        }
    }

}
