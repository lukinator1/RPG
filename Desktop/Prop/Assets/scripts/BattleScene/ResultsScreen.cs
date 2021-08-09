using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
        //this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                this.gameObject.SetActive(false);
                //this.enabled = false;
                Debug.Log("pop");
                GameObject.Find("Battlescene").GetComponentInChildren<BattleScene>().exitBattleScene();
            }
    }

    public void showResultsScreen()
    {
        this.gameObject.SetActive(true); //results screen/calculations here
        //this.enabled = true;
        /*AudioSource battlesong = GameObject.Find("BattleScene").GetComponentInChildren<BattleScene>().currentsong;
        battlesong.stop;
        battlesong.clip = PlayerObject.GetComponentInChildren<BattleScene>().battlescenesongs[1];
        battlesong.Play();*/
        Debug.Log("Results screen here."); 
    }
}
