﻿using System.Collections;
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
    public bool keypressed = false;
    public bool Collision = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(UserKey))
        {
            keypressed = true;
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
        else
        {
            keypressed = false;
        }

        if (currentItem)
        {
            currentItem.gameObject.transform.position = transform.position + objectHoldPosition;
        }
    }

    public Transform[] CollidersToTransforms(Collider[] collectablesFound)
    {
        Transform[] collectables = new Transform[collectablesFound.Length];
        for (int i = 0; i < collectablesFound.Length; i++)
        {
            collectables[i] = collectablesFound[i].gameObject.transform;
        }
        return collectables;
    }

    public Transform GetClosestCollectable(Transform[] collectable)
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

    public void grabItem(Transform tempItem)
    {
        currentItem = tempItem.gameObject;
        if (Collision == false)
        {
            SetAllCollidersStatus(false, currentItem.gameObject);
        }
        IsHolding = true;
    }

    public void dropItem()
    {
        if (currentItem)
        {
           SetAllCollidersStatus(true, currentItem.gameObject);
        }
        currentItem = null;
        IsHolding = false;
    }

    public void SetAllCollidersStatus(bool active, GameObject tempObject)
    {
        foreach (Collider c in tempObject.GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
