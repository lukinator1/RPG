using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    public SpriteRenderer battleentitityspriterenderer;
    public BattleScene battlescene;
    public StatusBox statusbox;
    public string name;
    public int battleentityposition; //with the way things work for now, battlentityposition will generally be expected to == playerparty position
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
            name = BattleSceneGlobalData.battlesceneglobalinstance.players[battleentityposition].playerdata.name;
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
            name = BattleSceneGlobalData.battlesceneglobalinstance.enemies[battleentityposition].localenemydata.name;
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
        if (HP <= 0.0f && KOd == false) //check if knocked out
        {
            HP = 0;
            KOd = true;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            if (tag == "PlayerCharacter") {
                battlescene.playersalive--;
                    }
            else if (tag == "Enemy")
            {
                battlescene.enemiesalive--;
            }
        }

    }

    public void Attack(BattleEntity enemytarget) //multipliers for attack can go here
    {
        //enemyentity = GameObject.Find("EnemyBattleEntity 1");
        //enemyentity.GetComponentInChildren<BattleEntity>().HP = 2.0F;
        float dmg = 7.0f;
        //enemytarget.GetComponentInChildren<BattleEntity>().HP -= dmg;
        //statusbox.GetComponentInChildren<StatusBox>().setText(name + " struck " + enemytarget.GetComponentInChildren<BattleEntity>().name + " for " + dmg.ToString() + " dmg.");
        enemytarget.HP -= dmg;
        statusbox.setText(name + " struck " + enemytarget.name + " for " + dmg.ToString() + " dmg.", false);
    }

    public void Skill(BattleEntity[] enemytargets)
    {

    }

    public void castMagic(Spell spell, List<BattleEntity> enemytargets)
    {
        if (mana >= spell.manacost) {
            Debug.Log("first here");
            spell.Cast(enemytargets);
            Debug.Log("second here");
            mana -= spell.manacost;
            string statusboxtext = "";
            for (int i = 0; i < enemytargets.Count; i++)
            {
                statusboxtext += (name + " struck " + enemytargets[i].name + " with " + spell.name + " for 7 dmg." + System.Environment.NewLine);
            }
            Debug.Log("third here");
            setStatusBoxText(statusboxtext, false);
            //statusbox.setText("o", true);
            Debug.Log("fourth here");
        }
        else
        {
            setStatusBoxText("Can't cast " + spell.name + ", out of mana!", false);
        }
    }

    public void Flee()
    {
        battlescene.battleEnd();
    }

    void setStatusBoxText(string statusboxtext, bool mutex)
    {
        statusbox.GetComponentInChildren<StatusBox>().setText(statusboxtext, mutex);
    }
}