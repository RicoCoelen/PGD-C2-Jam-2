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
    public GameObject CollectableObject;
    public LayerMask Players;
    public LayerMask Collectables;

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
                break;
        }
    }

    private void FixedUpdate()
    {
        Collider[] playersFound = Physics.OverlapSphere(baseCenter.transform.position, baseRange, Players);
        if (playersFound.Length > 0)
        {
            Transform[] playerTransform = GetComponent<PickUp>().CollidersToTransforms(playersFound);
            Transform goPlayer = GetComponent<PickUp>().GetClosestCollectable(playerTransform);
            PickUp closestPlayer = goPlayer.GetChild(0).gameObject.GetComponent<PickUp>();

            

            if (closestPlayer != null)
            {
                if (closestPlayer.IsHolding == false && closestPlayer.keypressed == true)
                {
                    // fix to get box
                    GameObject temp = Instantiate(CollectableObject, new Vector3(0, 0, 0), Quaternion.identity);
                    closestPlayer.grabItem(temp.transform);
                    baseStatus--;
                }

                if (closestPlayer.IsHolding == true && closestPlayer.keypressed == true)
                {
                    baseStatus++;
                    Destroy(closestPlayer.currentItem);
                    closestPlayer.currentItem = null;
                    closestPlayer.dropItem();
                }
            }
        }
    }

    void addResource(GameObject resource)
    {
        if (baseStatus > 0 && 5 < baseStatus)
        {
            //check if collectable == player
            if (baseStatus < 5)
            {
             
            }
            // player kan erin worden gezet
            baseStatus++;
        }
    }

    void removeResource(GameObject resource)
    {
        if (baseStatus > 0)
        {
            //check if collectable == player
            if (baseStatus > 4)
            {

            }
            Destroy(resource);
            baseStatus--;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(baseCenter.transform.position, baseRange);
    }
}
