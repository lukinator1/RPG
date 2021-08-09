using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public string name;
    public float manacost;
    public int targets;
    public Spell()
    { 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Cast(List<BattleEntity> spelltargets)
    {
        return true;
    }
}
