using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawn : MonoBehaviour
{
    public GameObject Collectable;
    
    public void OnMouseDown()
    {

        {
            Collectable.SetActive(true);
            Destroy(gameObject);
        }
    }
}
