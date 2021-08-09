using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class PlayerData : UnitData
{
    public int partyposition;
    public float maxmana;
    public float mana;
    public float currency;
    public float xp;
    public Dictionary<string, Spell> spells = new Dictionary<string, Spell>();
    public Inventory inventory = new Inventory();
    public Sprite icon;
    public Sprite[] battleentitysprites;
    public Sprite[] dialogueentitysprites;
    //SpriteRenderer m_SpriteRenderer;
    //public SpriteRenderer palyersprite;

    public PlayerData()
    {
        
    }
}
