using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCharacter : Unit
{
    public PlayerData playerdata = new PlayerData();
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters.ContainsKey(playerdata.name))
        {
            PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters.Add(playerdata.name, playerdata);
        }
        else
        {
            playerdata = PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters[playerdata.name];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SavePlayer()
    {
        PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters[playerdata.name] = playerdata;
    }

    public override UnitData getUnitData()
    {
        return playerdata;
    }

    public void sendDataToBattlescene()
    {
        BattleSceneGlobalData.battlesceneglobalinstance.players[playerdata.partyposition] = this;
    }

    public override void useItem(Item item)
    {
        item.Use(this);
    }

    public void calculateLevelUp()
    {
        int lvl = playerdata.lvl;
        if (playerdata.xp >= PlayerCharacterGlobalData.playercharacterglobalinstance.levels[lvl] && lvl <= 100) //100 max lvl for now
        {
            float xpleftover = playerdata.xp - PlayerCharacterGlobalData.playercharacterglobalinstance.levels[lvl];
            lvl++;
            while (xpleftover >= PlayerCharacterGlobalData.playercharacterglobalinstance.levels[lvl] && lvl <= 100) //check to see if got overlevels
            {
                xpleftover = playerdata.xp - PlayerCharacterGlobalData.playercharacterglobalinstance.levels[lvl];
                lvl++;
            }
            playerdata.lvl = lvl;
            return;
        }
        if (lvl >= 100) //if at max lvl, no more xp gains
        {
            playerdata.xp = -1;
        }
    }

}