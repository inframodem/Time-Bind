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
        None,
        Set,
        RedKey,
        BlueKey,
        YellowKey
    }
    //First slot holds a flag to check if any change has occured
    //Later additions the second slot will hold a death flag which will kill the other player if the player dies to prevent desyncs and to enforce teamwork
    public ItemList[] portal = { ItemList.None, ItemList.None, ItemList.None, ItemList.None, ItemList.None, ItemList.None, ItemList.None, ItemList.None, ItemList.None, ItemList.None }; //10
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
