using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGlobalData : MonoBehaviour
{
    public static InventoryGlobalData inventoryglobalinstance;
    public List<Item> globalinventory = new List<Item>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (inventoryglobalinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            inventoryglobalinstance = this;
        }
        else if (inventoryglobalinstance != this)
        {
            Destroy(gameObject);
        }
    }
}
