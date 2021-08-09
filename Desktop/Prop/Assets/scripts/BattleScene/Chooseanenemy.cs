using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chooseanenemy : MonoBehaviour
{
    public BattleScene battlescene;
    public GameObject magicmenu;
    public GameObject actionsmenu;
    public BattleEntity[] battleentitytargets; 
    int target = 1;
    string currentaction;
    int targetstochoose;
    bool[] chosentargets = new bool[12]; //max allies + maxenemies
    int actiontype; //0 = attack, 1 = skill, 2 = magic
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if ((Input.GetKeyDown(KeyCode.UpArrow) ^ Input.GetKeyDown(KeyCode.DownArrow) ^ Input.GetKeyDown(KeyCode.LeftArrow) ^ Input.GetKeyDown(KeyCode.RightArrow) ^ (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) ^ Input.GetKeyDown(KeyCode.C)) == true && (battlescene.bscenepaused == false)) //only accept 1 kind of input at a time
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    //choosingenemy = false;
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    if (actiontype == 0)
                    {
                        //actionmenu
                    }
                    else if (actiontype == 0)
                    {
                        //skillmenu
                    }
                    else if (actiontype == 2)
                    {
                        magicmenu.GetComponentInChildren<MagicMenu>().enabled = true;
                        this.enabled = false;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow)) //move pointer around
                {
                    if (chosentargets[target - 1] != true)
                    {
                        GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    }
                    findNextBattleEntityBelow();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    if (chosentargets[target - 1] != true)
                    {
                        GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    }
                    findNextBattleEntityAbove();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)) //move pointer around
                {
                    if (chosentargets[target - 1] != true)
                    {
                        GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    }
                    findLeftBattleEntity();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) //move pointer around
                {
                    if (chosentargets[target - 1] != true)
                    {
                        GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    }
                    findRightBattleEntity();
                    GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) //attack!!!!
                {
                    if (chosentargets[target - 1] == false)
                    {
                        chosentargets[target - 1] = true;
                        targetstochoose--;
                        if (targetstochoose == 0)
                        {
                            BattleEntity playerbattleentity = battlescene.currentplayer.GetComponentInChildren<BattleEntity>();
                            PlayerCharacter player = battlescene.players[playerbattleentity.battleentityposition];
                            if (actiontype == 0)
                            {
                                GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                                Debug.Log("attacking target: battleentity" + target.ToString());
                                BattleEntity bentity = new BattleEntity();
                                bentity = battleentitytargets[target];
                                playerbattleentity.Attack(battleentitytargets[target - 1]);
                                actionsmenu.GetComponentInChildren<ActionsMenuSelect>().enabled = true;
                                GameObject.Find("Menupointer1").GetComponentInChildren<Image>().enabled = true;
                            }
                            else if (actiontype == 1)
                            {
                                int skill = 0;
                            }
                            else if (actiontype == 2)
                            {
                                GameObject.Find("Enemypointer" + (target).ToString()).GetComponentInChildren<SpriteRenderer>().enabled = false;
                                List<BattleEntity> spelltargets = new List<BattleEntity>();
                                for (int i = 0; i < 12; i++)
                                {
                                    if (chosentargets[i] == true)
                                    {
                                        spelltargets.Add(battleentitytargets[i]);
                                        Debug.Log("casting upon target: battleentity" + (i + 1).ToString());
                                    }
                                }
                                playerbattleentity.castMagic(player.playerdata.spells[currentaction], spelltargets);
                                MagicMenu magicmenuclass = magicmenu.GetComponentInChildren<MagicMenu>();
                                magicmenuclass.enabled = true;
                                magicmenuclass.magicmenucursors[magicmenuclass.magicmenuselection].SetActive(true);
                            }
                            this.enabled = false;
                    }
                    }
                    else
                    {
                        //error pressing sound effect can go here
                    }
                }
            }
    }

    public void chooseEnemy(string action, int targetstochoose, int actiontype) //should be 1-8
    {
        this.actiontype = actiontype;
        if (actiontype == 0)
        {
            int actionmenu = 0;
        }
        else if (actiontype == 0)
        {
            int skillmenu = 1;
        }
        else if (actiontype == 2)
        {
            //magicmenu.SetActive(false);
            //magicmenu.GetComponentInChildren<MagicMenu>().enabled = false;
        }
        this.enabled = true;
        currentaction = action;
        this.targetstochoose = targetstochoose;
        for (int i = 0; i < 12; i++)
        {
            chosentargets[i] = false;
        }
        findTopmostAliveBattleEntity();
        GameObject.Find("Enemypointer" + target.ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true; //set pointer
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
