using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerStartHealth;
    public float playerHealth;
    private GameObject player1;
    private GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        playerHealth = playerStartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player1.transform.position, player2.transform.position) < 5 && Input.GetKeyDown("e"))
        {

        }

        if (Vector3.Distance(player1.transform.position, player2.transform.position) < 5 && Input.GetKeyDown("u"))
        {

        }
    }
}

