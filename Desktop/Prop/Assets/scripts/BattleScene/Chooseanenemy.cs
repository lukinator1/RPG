using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chooseanenemy : MonoBehaviour
{
    int target = 1;
    bool choosingenemy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (choosingenemy == true)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) ^ Input.GetKeyDown(KeyCode.DownArrow) ^ Input.GetKeyDown(KeyCode.LeftArrow) ^ Input.GetKeyDown(KeyCode.RightArrow) ^ (Input.GetKeyDown(KeyCode.T) || Input.GetMouseButtonDown(0))) == true) //only accept 1 kind of input at a time
            {
                if (Input.GetKeyDown(KeyCode.DownArrow)) //move pointer around
                {
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    findNextBattleEntityBelow();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    findNextBattleEntityAbove();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)) //move pointer around
                {
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    findLeftBattleEntity();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) //move pointer around
                {
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    findRightBattleEntity();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.T) || Input.GetMouseButtonDown(0)) //attack!!!!
                {
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    choosingenemy = false;
                    GameObject player = GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>().currentplayer;
                    Debug.Log("attacking target: battleentity" + target.ToString());
                    player.GetComponentInChildren<BattleEntity>().Attack(GameObject.Find("EnemyBattleEntity " + target.ToString()));
                }
            }
        }
    }

    public void chooseEnemy()
    {
        findTopmostAliveBattleEntity();
        GameObject.Find("Enemypointer" + target.ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true; //set pointer
        choosingenemy = true; 
    }

    void findTopmostAliveBattleEntity()
    {
        target = 1;
        while ((int)target <= BattleSceneGlobalData.battlesceneglobalinstance.enemies.Length) ///find topmost enemybattleentity
        {
            if (GameObject.Find("EnemyBattleEntity " + target.ToString()).GetComponentInChildren<BattleEntity>().KOd == false)
            {
                return;
            }
            target++;
        }
        Debug.Log("Are all the enemies dead?");
        //GameObject.Find("Enemypointer" + target.ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true; //set pointer
    }

   void findBottommostAliveBattleEntity()
    {
        target = BattleSceneGlobalData.battlesceneglobalinstance.enemies.Length;
        while ((int)target >= 1) ///find topmost enemybattleentity
        {
            if (GameObject.Find("EnemyBattleEntity " + target.ToString()).GetComponentInChildren<BattleEntity>().KOd == false)
            {
                return;
            }
            target--;
        }
        Debug.Log("Are all the enemies dead?");
    }

    void findNextBattleEntityBelow()
    {
        while ((int)target < BattleSceneGlobalData.battlesceneglobalinstance.enemies.Length)
        {
            target++;
            if (GameObject.Find("EnemyBattleEntity " + target.ToString()).GetComponentInChildren<BattleEntity>().KOd == false) //found one below
            {
                return; 
            }
        }
        findTopmostAliveBattleEntity();
    }

    void findNextBattleEntityAbove()
    {
        while ((int)target > 1)
        {
            target--;
            if (GameObject.Find("EnemyBattleEntity " + target.ToString()).GetComponentInChildren<BattleEntity>().KOd == false) //found one above
            {
                return;
            }
        }
        findBottommostAliveBattleEntity();
    }

    void findRightBattleEntity()
    {
        if (target == 1)
        {
            if (GameObject.Find("EnemyBattleEntity 5").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 5;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 2)
        {
            if (GameObject.Find("EnemyBattleEntity 6").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 6;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 3)
        {
            if (GameObject.Find("EnemyBattleEntity 7").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 7;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 4)
        {
            if (GameObject.Find("EnemyBattleEntity 8").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 8;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 5)
        {
            if (GameObject.Find("EnemyBattleEntity 1").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 1;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 6)
        {
            if (GameObject.Find("EnemyBattleEntity 2").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 2;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 7)
        {
            if (GameObject.Find("EnemyBattleEntity 3").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 3;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
        else if (target == 8)
        {
            if (GameObject.Find("EnemyBattleEntity 4").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 4;
            }
            else
            {
                findNextBattleEntityBelow();
            }
        }
    }

    void findLeftBattleEntity()
    {
        if (target == 1)
        {
            if (GameObject.Find("EnemyBattleEntity 5").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 5;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 2)
        {
            if (GameObject.Find("EnemyBattleEntity 6").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 6;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 3)
        {
            if (GameObject.Find("EnemyBattleEntity 7").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 7;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 4)
        {
            if (GameObject.Find("EnemyBattleEntity 8").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 8;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 5)
        {
            if (GameObject.Find("EnemyBattleEntity 1").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 1;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 6)
        {
            if (GameObject.Find("EnemyBattleEntity 2").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 2;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 7)
        {
            if (GameObject.Find("EnemyBattleEntity 3").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 3;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
        else if (target == 8)
        {
            if (GameObject.Find("EnemyBattleEntity 4").GetComponentInChildren<BattleEntity>().KOd == false)
            {
                target = 4;
            }
            else
            {
                findNextBattleEntityAbove();
            }
        }
    }
}
