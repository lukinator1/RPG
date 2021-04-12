using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGlobalData : MonoBehaviour
{
    public static NPCGlobalData npcglobalinstance;
    public Dictionary<string, NPCData> npcs = new Dictionary<string, NPCData>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        if (npcglobalinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            npcglobalinstance = this;
        }
        else if (npcglobalinstance != this)
        {
            Destroy(gameObject);
        }
    }
}
