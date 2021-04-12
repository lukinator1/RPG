using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Attackbutton : MonoBehaviour
{
    bool selected = true;
    bool chooseenemy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Y)){
            selected = true; 
        }
        if (selected && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            //GameObject.Find("PlayerBattleEntity " + selectEnemy().ToString()).GetComponentInChildren<BattleEntity>().Attack();
            this.gameObject.GetComponentInChildren<Button>().onClick.Invoke();
            selected = false;
            //GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>.choosingenemy = true;
        }*/
    }

    /*int selectEnemy()
    {
        int i = 1;
        string topenemy = "EnemyBattleEntity";
        while ((int)i <= BattleSceneGlobalData.battlesceneglobalinstance.enemies.Length) ///find topmost enemybattleentity
        {
            topenemy = "EnemyBattleEntity " + i.ToString();
            Debug.Log("Top enemy " + topenemy); 
            if (GameObject.Find("EnemyBattleEntity " + i.ToString()).activeInHierarchy == true)
            {
                break;
            }
            i++;
        }
        GameObject.Find("Enemypointer" + i.ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
        while(!(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))){
            if (Input.GetKeyDown(KeyCode.UpArrow) && !(Input.GetKeyDown(KeyCode.DownArrow)))
            {
                GameObject.Find("Enemypointer" + i.ToString()).GetComponentInChildren<SpriteRenderer>().enabled = true;
                Debug.Log("ADPOD");
            }
        }
        return i;
    }*/

}
