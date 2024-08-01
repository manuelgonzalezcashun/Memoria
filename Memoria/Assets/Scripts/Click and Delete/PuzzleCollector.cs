using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollector : MonoBehaviour
{
    public GameObject canvas3;
    public GameObject camera3;
    //public GameObject box;

    void OnMouseDown()
    {
        EventDispatcher.Raise(new CollectedEvent());
        canvas3.SetActive(false);
        camera3.SetActive(false);
        Destroy(gameObject);
        //box.GetComponent<BoxCollider>().enabled = false;
    }
}
