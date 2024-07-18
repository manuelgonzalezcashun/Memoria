using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private bool pickUpAllowed;


    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameVariables.keyCount += 2;
            pickUpAllowed = true;
            Debug.Log("hit");
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
