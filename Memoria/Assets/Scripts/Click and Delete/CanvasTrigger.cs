using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrigger : MonoBehaviour 
{

    public GameObject canvas2;

    public GameObject camera2;

    private bool openUpAllowed;


    private void Update()
    {
        if (openUpAllowed && Input.GetKeyDown(KeyCode.E))
            OpenUp();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            openUpAllowed = true;
            Debug.Log("hit");
        }
    }

    private void OpenUp()
    {
        canvas2.SetActive(true);
        camera2.SetActive(true);
        this.GetComponent<CanvasTrigger>().enabled = false;
    }
}
