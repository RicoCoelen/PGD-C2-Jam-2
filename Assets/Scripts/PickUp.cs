using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            foreach(GameObject item in items)
            {
                float distance = Vector3.Magnitude(transform.position - item.transform.position);
                if (distance < 2)
                {

                }
            }
        }
    }
}
