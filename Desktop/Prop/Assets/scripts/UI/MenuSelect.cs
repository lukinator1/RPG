using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public GameObject statusmenu;
    int menuchoice = 0; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Menubutton" + menuchoice.ToString() + " cursor").GetComponentInChildren<Image>().enabled = true;
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Menubutton" + menuchoice.ToString()).GetComponentInChildren<Button>().onClick.Invoke();
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) ^ (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) == false) //don't accept pressing both at same time
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject.Find("Menubutton" + menuchoice.ToString() + " cursor").GetComponentInChildren<Image>().enabled = false;
            menuchoice--;
            if (menuchoice == -1)
            {
                menuchoice = 6; 
            }
            GameObject.Find("Menubutton" + menuchoice.ToString() + " cursor").GetComponentInChildren<Image>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject.Find("Menubutton" + menuchoice.ToString() + " cursor").GetComponentInChildren<Image>().enabled = false;
            menuchoice++;
            if (menuchoice == 7)
            {
                menuchoice = 0;
            }
            Debug.Log(menuchoice); 
            GameObject.Find("Menubutton" + menuchoice.ToString() + " cursor").GetComponentInChildren<Image>().enabled = true;
        }
    }

    public void closeMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void openStatsMenu()
    {
        statusmenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void returnToTitleScreen() //make sure to save before leaving
    {
        SceneManager.LoadScene("Titlescreen");
    }
}
