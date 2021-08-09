using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicMenu : MonoBehaviour
{
    public BattleScene battlescene;
    public Chooseanenemy chooseanenemy;
    public GameObject actionsmenu;
    public Button[] magicmenubuttons;
    public Text[] magicmenutext;
    public GameObject[] magicmenucursors;
    public int magicmenuselection;
    List<string> playercharacterspells = new List<string>(); //may change to loading characters/spells in initially
    void Start()
    {
        
    }

    void Update()
    {
        if (battlescene.bscenepaused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            actionsmenu.SetActive(true);
            int actionmenucursornumber = actionsmenu.GetComponentInChildren<ActionsMenuSelect>().actionmenuselection;
            GameObject.Find("Menupointer" + (actionmenucursornumber).ToString()).GetComponentInChildren<Image>().enabled = true;
            this.gameObject.SetActive(false);
            magicmenucursors[magicmenuselection].SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            magicmenucursors[magicmenuselection].SetActive(false);
            magicmenuselection -= 2;
            if (magicmenuselection <= -1)
            {
                magicmenuselection = 5;
            }
            magicmenucursors[magicmenuselection].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            magicmenucursors[magicmenuselection].SetActive(false);
            magicmenuselection += 1;
            if (magicmenuselection >= 6)
            {
                magicmenuselection = 0;
            }
            magicmenucursors[magicmenuselection].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            magicmenucursors[magicmenuselection].SetActive(false);
            magicmenuselection -= 1;
            if (magicmenuselection <= -1)
            {
                magicmenuselection = 5;
            }
            magicmenucursors[magicmenuselection].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            magicmenucursors[magicmenuselection].SetActive(false);
            magicmenuselection += 2;
            if (magicmenuselection >= 6)
            {
                magicmenuselection = 0;
            }
            magicmenucursors[magicmenuselection].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            magicmenucursors[magicmenuselection].SetActive(false);
            magicmenubuttons[magicmenuselection].onClick.Invoke();
        }
    }

    public void showMagicMenu()
    {
        actionsmenu.SetActive(false);
        this.gameObject.SetActive(true);
        magicmenuselection = 0;
        GameObject player = GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>().currentplayer;
        //player.GetComponentInChildren<BattleEntity>().Attack(GameObject.Find("EnemyBattleEntity " + target.ToString()));
        //GameObject p = GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>().currentplayer;
        int playerindex = battlescene.currentplayer.GetComponentInChildren<BattleEntity>().battleentityposition;
        foreach (KeyValuePair<string, Spell> spell in (battlescene.players[playerindex].playerdata.spells))
        {
            playercharacterspells.Add(spell.Key);
            Debug.Log("po.po.]");
        }
        int i = 0;
        while (i < 6 && i != playercharacterspells.Count)
        {
            magicmenutext[i].text = playercharacterspells[i];
            i++;
        }
        if (i != 0)
        {
            magicmenucursors[0].SetActive(true);
        }
    }

    public void magicButtonPress()
    {
        int playerindex = battlescene.currentplayer.GetComponentInChildren<BattleEntity>().battleentityposition;
        chooseanenemy.chooseEnemy(magicmenutext[magicmenuselection].text, battlescene.players[playerindex].playerdata.spells[magicmenutext[magicmenuselection].text].targets, 2);
        this.enabled = false; 
    }
}
