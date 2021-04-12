using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{ 
    public PlayerData localPlayerCharacterData = new PlayerData();
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters.ContainsKey(localPlayerCharacterData.name))
        {
            PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters.Add(localPlayerCharacterData.name, localPlayerCharacterData);
        }
        else
        {
            localPlayerCharacterData = PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters[localPlayerCharacterData.name];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SavePlayer()
    {
        PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters[localPlayerCharacterData.name] = localPlayerCharacterData;
    }

    public void sendDataToBattlescene()
    {
        BattleSceneGlobalData.battlesceneglobalinstance.players[localPlayerCharacterData.partyposition] = this;
    }

    public void calculateLevelUp(PlayerData pdata)
    {

    }

}