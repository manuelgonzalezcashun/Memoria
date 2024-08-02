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

        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            Close();
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
    }
    private void Close()
    {
        canvas2.SetActive(false);
        camera2.SetActive(false);
    }
}
