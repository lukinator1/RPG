using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlobalData : MonoBehaviour
{
    public static EnemyGlobalData enemyglobalinstance;
    public Dictionary<string, EnemyData> enemies = new Dictionary<string, EnemyData>();
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
        if (enemyglobalinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            enemyglobalinstance = this;
        }
        else if (enemyglobalinstance != this)
        {
            Destroy(gameObject);
        }
    }
}
