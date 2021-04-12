using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(h * speed, v * speed);
        //gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y + (v * speed));

    }
}
