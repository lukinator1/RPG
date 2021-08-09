using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionsMenuSelect : MonoBehaviour
{
    public BattleScene battlescene;
    BattleEntity currentplayer;
    public Button magicbutton;
    bool choosingaction = true;
    public int actionmenuselection = 1;
    void Start()
    {
        actionmenuselection = 1;
        //magicbutton.onClick.AddListener(() => showMagicMenu(battlescene.currentplayer.GetComponentInChildren<PlayerCharacter>));
        GameObject.Find("Menupointer1").GetComponentInChildren<Image>().enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            choosingaction = true;
            GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = true;
        }
        if (choosingaction)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) ^ Input.GetKeyDown(KeyCode.DownArrow) ^ Input.GetKeyDown(KeyCode.LeftArrow) ^ Input.GetKeyDown(KeyCode.RightArrow) ^ (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))) == true && (battlescene.bscenepaused == false)) //only accept 1 kind of input at a time
            {
                if (Input.GetKeyDown(KeyCode.DownArrow)) //move pointer around
                {
                    GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = false;
                    if (actionmenuselection == 1)
                    {
                        actionmenuselection = 3;
                    }
                    else if (actionmenuselection == 2)
                    {
                        actionmenuselection = 4;
                    }
                    else if (actionmenuselection == 3)
                    {
                        actionmenuselection = 1;
                    }
                    else if (actionmenuselection == 4)
                    {
                        actionmenuselection = 2;
                    }
                    else if (actionmenuselection == 5)
                    {
                        actionmenuselection = 2;
                    }
                    GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = false;
                    if (actionmenuselection == 1)
                    {
                        actionmenuselection = 3;
                    }
                    else if (actionmenuselection == 2)
                    {
                        actionmenuselection = 4;
                    }
                    else if (actionmenuselection == 3)
                    {
                        actionmenuselection = 1;
                    }
                    else if (actionmenuselection == 4)
                    {
                        actionmenuselection = 2;
                    }
                    else if (actionmenuselection == 5)
                    {
                        actionmenuselection = 2;
                    }
                    GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    GameObject.Find("Menupointer" + actionmenuselection.ToString()).GetComponentInChildren<Image>().enabled = false;
                    actionmenuselection--;
                    if (actionmenuselection == 0)
                    {
                        actionmenuselection = 5;
                    }
                    GameObject.Find("Menupointer" + actionmenuselection.ToString()).GetComponentInChildren<Image>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) 
                {
                    GameObject.Find("Menupointer" + actionmenuselection.ToString()).GetComponentInChildren<Image>().enabled = false;
                    actionmenuselection++;
                    if (actionmenuselection == 6)
                    {
                        actionmenuselection = 1;
                    }
                    GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) //attack!!!!
                {
                    GameObject.Find("Menupointer" + (actionmenuselection).ToString()).GetComponentInChildren<Image>().enabled = false;
                    //choosingaction = false;
                    Debug.Log("actionmenuselection" + actionmenuselection);
                    if (actionmenuselection == 1)
                    {
                        GameObject.Find("Attackbutton").GetComponentInChildren<Button>().onClick.Invoke();
                    }
                    if (actionmenuselection == 2)
                    {
                        GameObject.Find("Skillbutton").GetComponentInChildren<Button>().onClick.Invoke();
                    }
                    if (actionmenuselection == 3)
                    {
                        GameObject.Find("Magicbutton").GetComponentInChildren<Button>().onClick.Invoke();
                    }
                    if (actionmenuselection == 4)
                    {
                        GameObject.Find("Itembutton").GetComponentInChildren<Button>().onClick.Invoke();
                    }
                    if (actionmenuselection == 5)
                    {
                        GameObject.Find("Fleebutton").GetComponentInChildren<Button>().onClick.Invoke();
                    }
                }
            }
        }
        
    }
}
