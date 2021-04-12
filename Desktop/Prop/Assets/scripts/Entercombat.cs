using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entercombat : MonoBehaviour
{
    public GameObject battlescene;
    public int numberofplayers;
    public int numberofenemies;
    public string[] battleconditions;
    public string weather;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entercombat collision with " + other.name + " occurred.");
        if (other.name == "PlayerParty")
        { 
            Debug.Log(other.name + " went into combat with " + name);
            other.transform.position = new Vector3(0, 5.5f, 0);
            /*BattleSceneGlobalData.battlesceneglobalinstance.battlescene = battlescene;
            BattleSceneGlobalData.battlesceneglobalinstance.numberofenemies = numberofenemies;
            BattleSceneGlobalData.battlesceneglobalinstance.battleconditions = battleconditions;
            BattleSceneGlobalData.battlesceneglobalinstance.weather = weather;*/
            SceneManager.LoadSceneAsync("battle scene"); //async usually preferred
        }
    }
}
