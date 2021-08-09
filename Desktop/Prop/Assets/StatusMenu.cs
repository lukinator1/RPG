using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMenu : MonoBehaviour
{
    public GameObject menu;
    public PlayerParty playerparty;
    public Text playercharactername;
    public Image currentplayericon;
    public Text lvl;
    public Text xptonextlvl;
    public HPbar hpbar;
    public Text maxHP;
    public Text currentHP;
    public Manabar manabar;
    public Text maxmana;
    public Text currentmana;
    int maxstatusmenuchoice;
    int statusmenuchoice = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxstatusmenuchoice = playerparty.partysize - 1;
        statusmenuchoice = 0;
        //currentplayericon.sprite = GameObject.Find("PlayerParty").GetComponentInChildren<PlayerParty>().playerchars[statusmenuchoice].playerdata.icon;
        //currentplayericon.sprite = playerparty.playerchars[statusmenuchoice].playerdata.icon;
        showPlayerStatus(playerparty.playerchars[statusmenuchoice]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M))
        {
            menu.SetActive(true);
            this.gameObject.SetActive(false);
            return;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) ^ (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) == false) //don't accept pressing both at same time
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            statusmenuchoice++;
            if (statusmenuchoice > maxstatusmenuchoice)
            {
                statusmenuchoice = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            statusmenuchoice--;
            if (statusmenuchoice < 0)
            {
                statusmenuchoice = maxstatusmenuchoice;
            }
        }

        showPlayerStatus(playerparty.playerchars[statusmenuchoice]); 
    }

    void showPlayerStatus(PlayerCharacter playercharacter)
    {
        playercharactername.text = playercharacter.playerdata.name;
        currentplayericon.sprite = playercharacter.playerdata.icon;
        lvl.text = playercharacter.playerdata.lvl.ToString();
        xptonextlvl.text = playercharacter.xpToNextLvl().ToString();
        hpbar.setHealthBar(playercharacter);
        maxHP.text = playercharacter.playerdata.maxHP.ToString();
        currentHP.text = playercharacter.playerdata.HP.ToString();
        manabar.setManaBar(playercharacter);
        maxmana.text = playercharacter.playerdata.maxmana.ToString();
        currentmana.text = playercharacter.playerdata.mana.ToString();
    }
}
