using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player")) PickupItem();
    }

    private void PickupItem()
    {
        Debug.Log("Picked up " + name);
        Destroy(gameObject);
    }
}
