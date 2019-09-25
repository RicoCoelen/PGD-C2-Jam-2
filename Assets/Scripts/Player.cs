using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject player1, player2;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player1.transform.position, player2.transform.position) < 2.5 && Input.GetKeyDown("e"))
        {
            player2.GetComponent<Health>().hp -= 12.5f;
            healthBar.fillAmount = player2.GetComponent<Health>().hp / player2.GetComponent<Health>().playerStartHealth;
        }

        if (Vector3.Distance(player1.transform.position, player2.transform.position) < 2.5 && Input.GetKeyDown("u"))
        {
            player1.GetComponent<Health>().hp -= 12.5f;
            healthBar.fillAmount = player1.GetComponent<Health>().hp / player1.GetComponent<Health>().playerStartHealth;
        }
    }
}
