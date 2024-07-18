using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour
{
    private bool openUpAllowed;

    public GameObject puzzlepiece;

    private void Update()
    {
        if (openUpAllowed && Input.GetKeyDown(KeyCode.E))
            OpenUp();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && GameVariables.keyCount>0)
        {
            GameVariables.keyCount --;
            openUpAllowed = true;
            Debug.Log("hit");
        }
    }

    private void OpenUp()
    {
        Destroy(gameObject);
        puzzlepiece.SetActive(true);
    }
}
