using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string name;
    public int partyposition;
    public float HP;
    public float mana;
    public float lvl;
    public float expgiven;
    public float currencygiven;
    public Item[] items;
    public Sprite[] battleentitysprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
