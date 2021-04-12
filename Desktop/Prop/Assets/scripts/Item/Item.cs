using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Item
{
    public string name = ""; //empty string is a blank item

    /*public Item(Item otheritem)
    {
        name = otheritem.name;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Use()
    {

    }
}
