using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BattleScene : MonoBehaviour
{
    public AudioSource currentsong;
    public AudioClip[] battlescenesongs;
    public StatusBox statusbox;
    public ResultsScreen resultsscreen;
    public PlayerCharacter[] players; 
    Enemy[] enemies;
    public int playersalive;
    public int enemiesalive;
    public string[] battleconditions;
    public string weather;
    bool choosingenemy;
    public string previousscene;
    public GameObject currentplayer;
    public bool bscenepaused = false;
    // Start is called before the first frame update
    void Start()
    {
        currentsong.clip = battlescenesongs[0];
        players = BattleSceneGlobalData.battlesceneglobalinstance.players;
        enemies = BattleSceneGlobalData.battlesceneglobalinstance.enemies;
        playersalive = players.Length;
        enemiesalive = enemies.Length;
        battleconditions = BattleSceneGlobalData.battlesceneglobalinstance.battleconditions;
        weather = BattleSceneGlobalData.battlesceneglobalinstance.weather;
        previousscene = BattleSceneGlobalData.battlesceneglobalinstance.previousscene;
        currentplayer = GameObject.Find("PlayerBattleEntity 1");
        bscenepaused = false;
    }

    void Awake()
    {
        //statusbox.GetComponentInChildren<Text>().text = "The battle has begun!";
    }

    // Update is called once per frame
    void Update()
    {
        if (bscenepaused == false)
        {
            if (playersalive == 0)
            {
                Debug.Log("DEAD");
                statusbox.setText("Game Over :(", true);
                battleEnd();
            }
            else if (enemiesalive == 0)
            {
                Debug.Log("DEAD AGAIN");
                //statusbox.setText("End of battle.");
                battleEnd();
            }
        }
    }

    public void playerFlee(GameObject currentplayer)
    {
        currentplayer.GetComponentInChildren<BattleEntity>().Flee();
    }

    public void playerMagic(GameObject currentplayer)
    {

    }

    public void battleEnd() //result calculations here
    {
        float totalgivenxp = 0;
        float totalcurrency = 0;
        List<Item> totalitemsdropped = new List<Item>(); 
        for (int i = 0; i < enemies.Length; i++)
        {
            totalgivenxp += enemies[i].localenemydata.expgiven;
            totalcurrency += enemies[i].localenemydata.currencygiven;
            totalitemsdropped.AddRange(enemies[i].localenemydata.items);
        }

        for (int i = 0; i < players.Length; i++)
        {
            if (GameObject.Find("PlayerBattleEntity " + (i + 1).ToString()).GetComponentInChildren<BattleEntity>().KOd == false) //only give exp if player is still alive
            {
                players[i].playerdata.xp += totalgivenxp;
                players[i].playerdata.currency += totalcurrency;
                //PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters[players[i].name]
                players[i].calculateLevelUp();

            }
        }
        //players[i].transferStats(PlayerCharacterGlobalData.playercharacterglobalinstance.playercharacters[players[i].name]);
        currentsong.Stop();
        currentsong.clip = battlescenesongs[1];
        currentsong.Play();
        bscenepaused = true;
        Debug.Log("end here");
        statusbox.setText("End of battle.", true);
        //statusbox.cancelcoroutine() something like this
        resultsscreen.showResultsScreen(); //pass in result calculations to results screen
    }

    public void exitBattleScene()
    {
        SceneManager.LoadScene(previousscene); //save all relevant player/enemy data here before leaving 
    }

}
