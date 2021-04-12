using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public int partysize;
    public float speed;
    public Rigidbody2D rigidbody;
    public AudioSource playeraudio;
    public AudioClip[] audioclips;
    int walkingsurfaceclip; //0 = grass
    bool walking = false; //walking toggle to determine audio
    // Start is called before the first frame update
    void Start()
    {
        playeraudio.clip = audioclips[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(h * speed, v * speed);
        Vector2 notmoving = new Vector2(0, 0);

        if (rigidbody.velocity == notmoving && walking == true)
        {
            playeraudio.Pause();
            walking = false;
        }
        else if (rigidbody.velocity != notmoving && walking == false)
        {
            playeraudio.Play();
            walking = true;
        }
    }
        

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with playerparty and " + other.name + " occurred.");
        if (playeraudio.clip != audioclips[0]) //set to default steps if not that alreadu
        {
            playeraudio.Pause();
            playeraudio.clip = audioclips[0];
            if (walking)
            {
                playeraudio.Play();
            }
        }
        if (other.gameObject.tag == "Enemy")  //send all data to battle scene
        {
            string currentlocation = SceneManager.GetActiveScene().name;
            BattleSceneGlobalData.battlesceneglobalinstance.background = currentlocation; //background

            switch (currentlocation) //some logic to determine the weather can go here  //weather
            {
                case "starting zone outside":
                    BattleSceneGlobalData.battlesceneglobalinstance.weather = "sunny";
                    break;
            }

            PlayerCharacter[] playercharacters; //player characters 
            playercharacters = GetComponentsInChildren<PlayerCharacter>();
            Array.Clear(BattleSceneGlobalData.battlesceneglobalinstance.players, 0, BattleSceneGlobalData.battlesceneglobalinstance.players.Length);
            foreach (PlayerCharacter pc in playercharacters)
            {
                pc.sendDataToBattlescene();
                //Debug.Log(pc.name + " sent data to battle scene");
            }

            Enemy[] enemies; //enemies
            enemies = other.gameObject.GetComponentsInChildren<Enemy>();
            Array.Clear(BattleSceneGlobalData.battlesceneglobalinstance.enemies, 0, BattleSceneGlobalData.battlesceneglobalinstance.enemies.Length);
            foreach (Enemy enemy in enemies)
            {
                enemy.sendDataToBattleScene();
            }

            string[] battleconditions = { "Standard Battle" }; //some logic for battle conditions can go here (position, player chars, enemy chars, etc.)
            BattleSceneGlobalData.battlesceneglobalinstance.battleconditions = battleconditions;

            BattleSceneGlobalData.battlesceneglobalinstance.previousscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("battle scene");
        }
        else if (other.gameObject.tag == "Environment"){
            if (other.gameObject.name.Substring(0, 5) == "Grass")
            {
                playeraudio.Pause();
                playeraudio.clip = audioclips[1];
                if (walking)
                {
                    playeraudio.Play();
                }
            }
        }
        /*else if (other.gameObject.tag == "NPC")f
        {
            rigidbody.velocity = new Vector2(0, 0);
        }*/
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        rigidbody.velocity = new Vector2(0, 0);
    }*/

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit collision with playerparty and " + other.name + " occurred."); //probably recheck if colliding with different floor here
        if (other.gameObject.tag == "Environment")
        {
            playeraudio.Pause();
            playeraudio.clip = audioclips[0];
            if (walking)
            {
                playeraudio.Play();
            }
        }
    }
}
