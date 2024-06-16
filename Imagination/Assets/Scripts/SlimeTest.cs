using UnityEngine;

public class SlimeTest : MonoBehaviour
{
    public GameObject go;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            go.SetActive(true);
        }
    }
}
