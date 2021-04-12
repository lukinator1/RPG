using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enterexitscene : MonoBehaviour
{
    public Vector3 playerspawnposition;
    public string scenetospawnin;
    //private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     //speed = speed * -1;
     //Destroy(gameObject);
        Debug.Log("Enterexitscene collision with " + other.name + " occurred.");
        if (other.name == "PlayerParty")
        {
            Debug.Log(other.name + " went into " + scenetospawnin + "scene.");
            SceneManager.LoadScene(scenetospawnin); //async usually preferred
            other.transform.position = playerspawnposition;
        }
    }
}
