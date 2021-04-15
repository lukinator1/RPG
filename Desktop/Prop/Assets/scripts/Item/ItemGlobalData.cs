using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGlobalData : MonoBehaviour
{
    public static ItemGlobalData itemsglobalinstance;
    public Dictionary<string, string> globalitems = new Dictionary<string, string>();
    void Start()
    {

    }

    void Update()
    {

    }

    void Awake()
    {
        if (itemsglobalinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            itemsglobalinstance = this;
        }
        else if (itemsglobalinstance != this)
        {
            Destroy(gameObject);
        }
    }
}
