using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class PlayerData
{
    public string name;
    public int partyposition;
    public int lvl;
    public float HP;
    public float mana;
    public Inventory inventory;
    public float currency;
    public float xp;
    public Sprite[] battleentitysprites;
    public Sprite[] dialogueentitysprites;
    //SpriteRenderer m_SpriteRenderer;
    //public SpriteRenderer palyersprite;

    // Start is called before the first frame update
    void Start()
    {
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //palyersprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void transferStats(PlayerData player)
    {
        player.HP = HP;
        player.mana = mana;
        player.lvl = lvl;
        player.xp = xp;
    }
}
