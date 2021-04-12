using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSceneGlobalData : MonoBehaviour
{
    public static DialogueSceneGlobalData dialoguesceneglobaldatainstance;
    public Sprite[] leftdialogueentitysprites;
    public Sprite[] rightdialogueentitysprites;
    public bool dialogueon;
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
        if (dialoguesceneglobaldatainstance == null)
        {
            DontDestroyOnLoad(gameObject);
            dialoguesceneglobaldatainstance = this;
        }
        else if (dialoguesceneglobaldatainstance != this)
        {
            Destroy(gameObject);
        }
    }
}
