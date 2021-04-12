using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    public SpriteRenderer battleentitityspriterenderer;
    public GameObject enemyentity;
    public int battleentityposition;
    public float HP;
    public float mana;
    public float lvl;
    public bool KOd = false;
    public Sprite[] battleentitysprites;
    // Start is called before the first frame update
    //sprite, animations, player stats, battleconditions
    void Start()
    {
        Debug.Log("hi");
        if (tag == "PlayerCharacter") {
            if ((battleentityposition + 1) > BattleSceneGlobalData.battlesceneglobalinstance.players.Length)
            {
                this.gameObject.SetActive(false);
                //Debug.Log("Battleentityposition: " + battleentityposition.ToString() + ", playercount: " + BattleSceneGlobalData.battlesceneglobalinstance.players.Length);
                return;
            }
            battleentitysprites = BattleSceneGlobalData.battlesceneglobalinstance.players[battleentityposition].playerdata.battleentitysprites;
            HP = BattleSceneGlobalData.battlesceneglobalinstance.players[battleentityposition].playerdata.HP;
            mana = BattleSceneGlobalData.battlesceneglobalinstance.players[battleentityposition].playerdata.mana;
            lvl = BattleSceneGlobalData.battlesceneglobalinstance.players[battleentityposition].playerdata.lvl;
            //Debug.Log(battleentityposition.ToString());
            Debug.Log(BattleSceneGlobalData.battlesceneglobalinstance.players[battleentityposition].playerdata.name + " entered the battle, hp: " + HP + " mana: " + mana + " lvl: " + lvl);
            battleentitityspriterenderer.sprite = battleentitysprites[0];
            this.gameObject.SetActive(true);
        }
        else if (tag == "Enemy")
        {
            if ((battleentityposition + 1) > BattleSceneGlobalData.battlesceneglobalinstance.enemies.Length)
            {
                this.gameObject.SetActive(false);
                return;
            }
            battleentitysprites = BattleSceneGlobalData.battlesceneglobalinstance.enemies[battleentityposition].localenemydata.battleentitysprites;
            HP = BattleSceneGlobalData.battlesceneglobalinstance.enemies[battleentityposition].localenemydata.HP;
            mana = BattleSceneGlobalData.battlesceneglobalinstance.enemies[battleentityposition].localenemydata.mana;
            lvl = BattleSceneGlobalData.battlesceneglobalinstance.enemies[battleentityposition].localenemydata.lvl;
            Debug.Log(BattleSceneGlobalData.battlesceneglobalinstance.enemies[battleentityposition].localenemydata.name + " entered the battle, hp: " + HP + " mana: " + mana + " lvl: " + lvl);
            battleentitityspriterenderer.sprite = battleentitysprites[0];
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0.0f)
        {
            KOd = true;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

    }

    public void Attack(GameObject enemytarget) //multipliers for attack can go here
    {
        //enemyentity = GameObject.Find("EnemyBattleEntity 1");
        //enemyentity.GetComponentInChildren<BattleEntity>().HP = 2.0F;
        enemytarget.GetComponentInChildren<BattleEntity>().HP -= 3.0f;
    }

    public void Flee()
    {
        GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>().battleEnd();
    }
}
