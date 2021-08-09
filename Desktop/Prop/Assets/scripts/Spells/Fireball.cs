using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    public float manacost = 5.0f;
    AudioSource fireballsoundeffect;
    //animation/particle effects should be here

    public Fireball()
    {
        name = "Fireball";
        manacost = 5.0f;
        targets = 1;
    }

    public override bool Cast(List <BattleEntity> spelltargets)
    {
        //GameObject.Find("Battlescene").GetComponentInChildren<Chooseanenemy>.chooseEnemy
        spelltargets[0].HP -= 7.0f;
        return true;
    }
}
