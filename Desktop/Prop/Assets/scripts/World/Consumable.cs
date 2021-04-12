using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Consumable : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use() {
        //Consume();
    }

    public virtual void Consume(GameObject unit)
    {

    }
}
