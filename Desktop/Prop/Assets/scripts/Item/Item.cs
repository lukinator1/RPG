using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Item
{
    public string name = ""; //may switch to itemdata at some point
    void Start()
    {
        if (!ItemGlobalData.itemsglobalinstance.globalitems.ContainsKey(name))
        {
            ItemGlobalData.itemsglobalinstance.globalitems.Add(name, name);
        }
        else //would probably check for differences between duplicate items here
        {
            name = ItemGlobalData.itemsglobalinstance.globalitems[name];
        }
    }

    /*void Awake() { 
            DontDestroyOnLoad(this.gameObject);
    }*/

    public void dontDestroy()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

    }

    public void saveItemToGlobalInstance()
    {
        ItemGlobalData.itemsglobalinstance.globalitems[name] = name;
    }

    public virtual void Use(Unit unit)
    {
        Debug.Log("0.0");
    }
}
