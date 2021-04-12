using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreen : MonoBehaviour
{
    bool resultsscreen = false; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resultsscreen) //probably should be a button
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>().leavecombat = true; 
            }
        }
    }

    public void showResultsScreen()
    {
        resultsscreen = true; //results screen/calculations here
        /*AudioSource battlesong = GameObject.Find("BattleScene").GetComponentInChildren<BattleScene>().currentsong;
        battlesong.stop;
        battlesong.clip = PlayerObject.GetComponentInChildren<BattleScene>().battlescenesongs[1];
        battlesong.Play();*/
        Debug.Log("Results screen here."); 
    }
}
