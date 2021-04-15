using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class Inventory
{
    public Item[] items;
    public int firstopenspace = 0;
    public int spaceremaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("o.0.o0-");
        if (InventoryGlobalData.inventoryglobalinstance.globalinventory.Count < items.Length)
        {
            InventoryGlobalData.inventoryglobalinstance.globalinventory.AddRange(items);
            Debug.Log("sent");
        }
        else //would probably check for differences between duplicate items here
        {
            items[0] = InventoryGlobalData.inventoryglobalinstance.globalinventory[0];
            Debug.Log("received");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addToInventory(Item item) //returns true if successful, false if not
    {
        if (spaceremaining != 0) {
            //Item i = new Item();
            //i.name = "ASDF";
            //UnityEngine.Object.DontDestroyOnLoad(i.gameObject);
            items[firstopenspace] = item;
            Debug.Log(items[firstopenspace].name);
            //items[firstopenspace].dontDestroy();
            spaceremaining--;
            calculateFirstOpenSpace(firstopenspace + 1);
            return true;
        }
        return false; 
    }

    void calculateFirstOpenSpace(int startingindex) //if firstopenspace == -1, there is no open space
    {
        int checkahead = startingindex;
        Debug.Log("checkahead: " + checkahead.ToString());
        Debug.Log(items.Length);
        while (checkahead < items.Length) //check in front first
        {
            if (items[checkahead].name == "")
            {
                firstopenspace = checkahead;
                return;
            }
            checkahead++;
        }
        int checkbehind = 0;
        while (checkbehind < startingindex)
        {
            if (items[checkbehind].name == "")
            {
                firstopenspace = checkbehind;
                return;
            }
            checkbehind++;
        }
        firstopenspace = -1;
    }
}
