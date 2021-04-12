using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterGlobalData : MonoBehaviour
{
    public static PlayerCharacterGlobalData playercharacterglobalinstance;
    public Dictionary<string, PlayerData> playercharacters = new Dictionary<string, PlayerData>();
    public float[] levels = new float[5] {10.0f, 24.0f, 72.0f, 112.0f, 120.0f}; //each index in array says xp a level has (should be 100 when done) 
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
        if (playercharacterglobalinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            playercharacterglobalinstance = this;
        }
        else if (playercharacterglobalinstance != this)
        {
            Destroy(gameObject);
        }
    }
}
