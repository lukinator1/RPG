using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HealthPotion : Consumable
{
    /*void Start()
    {
        ontDestroyOnLoad(this.gameObject);
    }*/
    public override void Use(Unit unit)
    {
        unit.getUnitData().HP += 5.0f;
        Debug.Log("Consumed HP Potion");
    }
}
