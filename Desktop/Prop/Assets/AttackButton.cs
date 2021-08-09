using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    //Battlescene battlescene;
    public Chooseanenemy chooseanenemy;
    public ActionsMenuSelect actionmenu;
    //Text attackbuttontext;
    public void attackButtonPress()
    {
        actionmenu.enabled = false;
        chooseanenemy.chooseEnemy("Attack", 1, 0);
    }
}
