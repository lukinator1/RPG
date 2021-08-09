using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class StatusBox : MonoBehaviour
{
    public Text statusboxtext;
    bool mutex = false;
    IEnumerator currenttextanimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        setText("The battle has begun!", false);
    }

    // Update is called once per frame
    void Update()
    {
        //setText("O.O.O.O.O");   
    }

    public void setText(string txt, bool mutex)
    {
        /*if (this.mutex)
        {
            Debug.Log(txt + " returned!");
            return;
        }
        this.mutex = mutex;*/
        char[] letters = txt.ToCharArray();
        currenttextanimation = textAnimation(txt);
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
        /*if (this.mutex)
        {
            yield return new WaitForSeconds(5.0f);
        }
        this.mutex = false;*/
    }
}
