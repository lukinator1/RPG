using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider HPbarslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealthBar(PlayerCharacter player)
    {
        HPbarslider.maxValue = player.playerdata.maxHP;
        HPbarslider.value = player.playerdata.HP;
    }
}
