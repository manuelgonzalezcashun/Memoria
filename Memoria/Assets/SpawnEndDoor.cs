using UnityEngine;

public class SpawnEndDoor : MonoBehaviour
{
    void OnEnable()
    {
        EventDispatcher.AddListener<SpawnDoor>(ctx => gameObject.SetActive(true));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<SpawnDoor>(ctx => gameObject.SetActive(true));
    }
}
