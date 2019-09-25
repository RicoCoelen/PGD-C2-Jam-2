using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject[] items;
    public bool IsHolding = false;
    public GameObject currentItem;
    public float grabRange;
    public LayerMask collectablesMask;
    public Vector3 objectHoldPosition;
    public KeyCode UserKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(UserKey))
        {
            Collider[] collectablesFound = Physics.OverlapSphere(transform.position, grabRange, collectablesMask);
            Transform[] collectableTransform = CollidersToTransforms(collectablesFound);
            Transform tempitem = GetClosestCollectable(collectableTransform);

            if (tempitem && IsHolding == false)
            {
                grabItem(tempitem);
            }
            else
            {
                dropItem();
            }
        }

        if (currentItem)
        {
            currentItem.gameObject.transform.position = transform.position + objectHoldPosition;
        }

    }

    Transform[] CollidersToTransforms(Collider[] collectablesFound)
    {
        Transform[] collectables = new Transform[collectablesFound.Length];
        for (int i = 0; i < collectablesFound.Length; i++)
        {
            collectables[i] = collectablesFound[i].gameObject.transform;
        }
        return collectables;
    }

    Transform GetClosestCollectable(Transform[] collectable)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in collectable)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    void grabItem(Transform tempItem)
    {
        currentItem = tempItem.gameObject;
        currentItem.gameObject.GetComponent<BoxCollider>().enabled = false;
        IsHolding = true;
    }

    void dropItem()
    {
        if (currentItem)
        {
            currentItem.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        currentItem = null;
        IsHolding = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }

}
