using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System;

public class InventoryItems : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D item)
    {
        if (item.gameObject.tag == ("Player"))
        {
            transform.position = new Vector3(-1.979272f, 8.67f, 1.0f);
            item.gameObject.GetComponent<PlayerMovement>().key1 = true;
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
 
    }
}
