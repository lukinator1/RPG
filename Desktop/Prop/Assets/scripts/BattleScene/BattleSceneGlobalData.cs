using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneGlobalData : MonoBehaviour
{
    public static BattleSceneGlobalData battlesceneglobalinstance;
    public string background;
    public PlayerCharacter[] players;
    public Enemy[] enemies;
    //public Sprite[] battlenntitysprites;
    public string[] battleconditions; 
    public string weather;
    public string previousscene; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (battlesceneglobalinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            battlesceneglobalinstance = this;
        }
        else if (battlesceneglobalinstance != this)
        {
            Destroy(gameObject);
        }
    }
}
