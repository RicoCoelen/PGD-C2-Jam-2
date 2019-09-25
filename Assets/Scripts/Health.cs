
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float playerStartHealth;
    
    public float hp;
    

    public void Start()
    {
        hp = playerStartHealth;
    }
}
