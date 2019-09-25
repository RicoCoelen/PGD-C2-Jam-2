using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public int baseStatus = 0;
    public GameObject baseCenter;
    public float baseRange;
    public GameObject Totem1;
    public GameObject Totem2;
    public GameObject Totem3;
    public GameObject Totem4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // remove totem
        Totem1.SetActive(false);
        Totem2.SetActive(false);
        Totem3.SetActive(false);
        Totem4.SetActive(false);

        // show active totems
        switch (baseStatus)
        {
            case 5:
                print("Game Won By: Bla");
                goto case 4;
            case 4:
                Totem4.SetActive(true);
                goto case 3;
            case 3:
                Totem3.SetActive(true);
                goto case 2;
            case 2:
                Totem2.SetActive(true);
                goto case 1;
            case 1:
                Totem1.SetActive(true);
                break;
            default:
                print("still 0");
                break;
        }
    }

    void addResource()
    {

    }

    void removeResource()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(baseCenter.transform.position, baseRange);
    }
}
