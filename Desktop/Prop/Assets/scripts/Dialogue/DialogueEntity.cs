using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEntity : MonoBehaviour
{
    public SpriteRenderer dialogueentityspriterenderer; //whether talking, sprites, dialogue, and logic
    public Sprite[] dialoguesprites;
    int dialogueentityposition;
    bool dialogueon = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueSceneGlobalData.dialoguesceneglobaldatainstance.dialogueon == true)
        {
            if (dialogueentityposition == 0){
                dialoguesprites = DialogueSceneGlobalData.dialoguesceneglobaldatainstance.leftdialogueentitysprites;
               }
            else if (dialogueentityposition == 1){
                dialoguesprites = DialogueSceneGlobalData.dialoguesceneglobaldatainstance.rightdialogueentitysprites; 
            }
        }
    }
}
