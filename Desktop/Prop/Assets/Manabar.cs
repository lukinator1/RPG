using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
    public Slider manabarslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setManaBar(PlayerCharacter player)
    { 
        manabarslider.maxValue = player.playerdata.maxmana;
        manabarslider.value = player.playerdata.mana;
    }
}
