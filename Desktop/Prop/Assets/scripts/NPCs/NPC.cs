using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCData localNPCData = new NPCData();
    bool ekeydown = false;
    bool nearplayer = false;
    bool talking = false;
    // Start is called before the first frame update
    //load npc with global data
    void Start()
    {
        if (!NPCGlobalData.npcglobalinstance.npcs.ContainsKey(localNPCData.name))
        {
            NPCGlobalData.npcglobalinstance.npcs.Add(localNPCData.name, localNPCData);
        }
        else
        {
            localNPCData = NPCGlobalData.npcglobalinstance.npcs[localNPCData.name];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearplayer == true)
        {
            Debug.Log("E!");
            startDialogueBranch();
            ekeydown = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        nearplayer = true;
        /*Debug.Log("hit npc");
        if (other.gameObject.name == "PlayerParty") {
            other.gameObject.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                startDialogueBranch(localNPCData.npcDialogue);
            }
        }*/
    }

    void OnTriggerStay2D(Collider2D other)
    {
        /*if (ekeydown)
        {
            ekeydown = false;
            Debug.Log("o.o.o.");
            startDialogueBranch(localNPCData.npcDialogue);
        }
        Debug.Log("staying in npc");
        if (other.gameObject.name == "PlayerParty")
        {
            other.gameObject.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                startDialogueBranch(localNPCData.npcDialogue);
            }
        }*/
    }

    void OnTriggerExit2D(Collider2D other)
    {
        nearplayer = false;
    }

    void startDialogueBranch()
    {

        Debug.Log("npc dialogue branch started");
        gameObject.GetComponentInChildren<NPCDialogue>().doDialogue();
    }

    //save local npc data to global instace
    public void SaveNPC()
    {
        NPCGlobalData.npcglobalinstance.npcs[localNPCData.name] = localNPCData;
    }
}
