using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    public Transform player1;
    public Transform player2;
    // Start is called before the first frame update
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            float distance = Vector3.Distance(player1.position, interactionTransform.transform.position);
            float distance1 = Vector3.Distance(player2.position, interactionTransform.transform.position);
            if (distance <= radius)
            {
                Debug.Log("interact player 1");
                Interact();
            }
            if (distance1 <= radius)
            {
                Debug.Log("interact player 2");
                Interact();
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
