using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    //holds values for item transfer
    public enum ItemList
    {
        None, // 0
        Set,  // 1
        RedKey, // 2
        BlueKey, // 3
        YellowKey, // 4
        CrowBar, // 5
        Axe, // 6
        GreenChemical, //7
        PurpleChemical, //8
        YellowChemical //9
        ,Crate,//10
        SpecialCrate//11

    }
    //First slot holds a flag to check if any change has occured
    //Later additions the second slot will hold a death flag which will kill the other player if the player dies to prevent desyncs and to enforce teamwork
    //Third element is win check
    public ItemList[] portal = new ItemList[40]; //40
    //methods for getting and setting save data in the portal array
    public virtual int getItem(int i)
    {
        return (int)portal[i];
    }
    public virtual void setItem(int i, int set)
    {
        portal[i] = (ItemList)set;
    }
    public virtual int getListLength()
    {
        return portal.Length;
    }
}
