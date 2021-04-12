using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData localenemydata = new EnemyData();
    // Start is called before the first frame update
    //load npc with global data
    void Start()
    {
        /*if (!EnemyGlobalData.enemyglobalinstance.enemies.ContainsKey(localenemydata.name))
        {
            EnemyGlobalData.enemyglobalinstance.enemies.Add(localenemydata.name, localenemydata);
        }
        else
        {
            localenemydata = EnemyGlobalData.enemyglobalinstance.enemies[localenemydata.name];
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void sendDataToBattleScene()
    {
        BattleSceneGlobalData.battlesceneglobalinstance.enemies[localenemydata.partyposition] = this;
    }

    //save local npc data to global instace
    public void SaveEnemy()
    {
        //EnemyGlobalData.enemyglobalinstance.enemies[localenemydata.name] = localenemydata;
    }

}
