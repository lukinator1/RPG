using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerParty : MonoBehaviour //representing the player party sprite/entity that you'll see in the open world
{
    List<PlayerCharacter> playerchars;
    public int partysize;
    public float speed;
    public Rigidbody2D rigidbody;
    public AudioSource playeraudio;
    public AudioClip[] audioclips;
    List<GameObject> nearbygameobjects = new List<GameObject>();
    public GameObject menu;
    bool nearitem = false;
    int walkingsurfaceclip; //0 = grass
    bool walking = false; //walking toggle to determine audio
    // Start is called before the first frame update
    void Start()
    {
        /*if (playerchars.Count != partysize)
        {
            playerchars.AddRange(this.gameObject.GetComponentsInChildren<PlayerCharacter>());
        }*/
        playeraudio.clip = audioclips[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(h * speed, v * speed);
        Vector2 notmoving = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.E))
            {
            if (nearbygameobjects.Count != 0)
                {
                Interact(nearbygameobjects[0]);
                }
            }

        if (Input.GetKeyDown(KeyCode.M))
        {
            menu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(nearbygameobjects.Count.ToString() + " nearbygameobjects: ");
            for (int i = 0; i < nearbygameobjects.Count; i++)
            {
                Debug.Log(nearbygameobjects[i].tag);
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(GameObject.Find("Main Character").GetComponentInChildren<PlayerCharacter>().playerdata.inventory.spaceremaining.ToString() + GameObject.Find("Main Character").GetComponentInChildren<PlayerCharacter>().playerdata.inventory.firstopenspace.ToString());
            Debug.Log(GameObject.Find("Main Character").GetComponentInChildren<PlayerCharacter>().playerdata.inventory.items[0].name);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.Find("Main Character").GetComponentInChildren<PlayerCharacter>().useItem(GameObject.Find("Main Character").GetComponentInChildren<PlayerCharacter>().playerdata.inventory.items[0]);
            Debug.Log("Item used.");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("HP: " + GameObject.Find("Main Character").GetComponentInChildren<PlayerCharacter>().playerdata.HP);
        }

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
        if (playeraudio.clip != audioclips[0]) //set to default steps if not that already
        {
            playeraudio.Pause();
            playeraudio.clip = audioclips[0];
            if (walking)
            {
                playeraudio.Play();
            }
        }
        if (other.gameObject.tag == "Environment"){
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
        if (other.gameObject.tag == "Item") //probably want to calculate what it's closer to here
        {
            nearbygameobjects.Add(other.gameObject);
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
        /*else if (other.gameObject.tag == "NPC")
        {
            rigidbody.velocity = new Vector2(0, 0);
        }*/
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //nearbygameobjects.calculateDistance //probably want to calculate what it's closer to here
        //nearbygameobjects.sortByClosest

    }

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
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "NPC")
        {
            nearbygameobjects.Remove(other.gameObject);
        }
    }

    bool pickUp(Itempiece itempiece)
    {
        PlayerCharacter[] playerchars = this.gameObject.GetComponentsInChildren<PlayerCharacter>();
        for (int i = 0; i < playerchars.Length; i++) //1st char with space picks it up
        {
            //Debug.Log(playerchars[i].playerdata.inventory.firstopenspace);
            if (playerchars[i].playerdata.inventory.addToInventory(itempiece.item))
            {
                return true;
            }
        }
        return false; 
    }

    void Interact(GameObject othergameobject)
    {
        if (othergameobject.tag == "NPC")
        {

        }
        else if (othergameobject.tag == "Item")
        {
            if (pickUp(othergameobject.GetComponentInChildren<Itempiece>()) == true)
            {
                nearbygameobjects.Remove(othergameobject);
                Destroy(othergameobject);
            }
            else //say that you're out of inventory space here
            {
                Debug.Log("I'm out of inventory space");
            }
        }
    }
}
