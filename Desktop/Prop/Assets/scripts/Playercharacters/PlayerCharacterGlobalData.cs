using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterGlobalData : MonoBehaviour
{
    public static PlayerCharacterGlobalData playercharacterglobalinstance;
    public Dictionary<string, PlayerData> playercharacters = new Dictionary<string, PlayerData>();
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
            Debug.Log("1");
        }
        else if (playercharacterglobalinstance != this)
        {
            Destroy(gameObject);
            Debug.Log("2");
        }
    }
}
