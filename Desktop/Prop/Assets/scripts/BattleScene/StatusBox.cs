using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class StatusBox : MonoBehaviour
{
    public Text statusboxtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        setText("The battle has begun!");
    }

    // Update is called once per frame
    void Update()
    {
        //setText("O.O.O.O.O");   
    }

    public void setText(string txt)
    { 
        char[] letters = txt.ToCharArray();
        StartCoroutine(textAnimation(txt));
    }

    IEnumerator textAnimation(string letters)
    {
        int i = 0;
        StringBuilder statustxt = new StringBuilder(letters.Length);
        while (i < letters.Length)
        {
            yield return new WaitForSeconds(.05f);
            statustxt.Append(letters[i]); //sound effect/animation here
            statusboxtext.text = statustxt.ToString();
            i++;
        }
    }
}
