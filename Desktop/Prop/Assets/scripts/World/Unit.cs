using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    /*Unit()
    {
        if (this.gameObject.Tag == "PlayerCharacter")
        {
            unitdata == new Player
        }
    }*/

    public virtual void useItem(Item item)
    {

    }

    public virtual UnitData getUnitData()
    {
        return new UnitData();
    }
}
