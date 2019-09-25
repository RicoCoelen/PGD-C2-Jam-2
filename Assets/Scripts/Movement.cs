using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 velocity;
    public float speed = 10;

    public Interactable focus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;

        if (tag == "Player1")
        {

            if (Input.GetKey("w"))
            {
                velocity.y += 1;
            }
            if (Input.GetKey("a"))
            {
                velocity.x -= 1;
            }
            if (Input.GetKey("s"))
            {
                velocity.y -= 1;
            }
            if (Input.GetKey("d"))
            {
                velocity.x += 1;
            }
        }
        if(tag == "Player2")
        {
            if (Input.GetKey("up"))
            {
                velocity.y += 1;
            }
            if (Input.GetKey("left"))
            {
                velocity.x -= 1;
            }
            if (Input.GetKey("down"))
            {
                velocity.y -= 1;
            }
            if (Input.GetKey("right"))
            {
                velocity.x += 1;
            }
        }
        velocity *= speed * Time.deltaTime;
        transform.position += velocity;


    }
}
