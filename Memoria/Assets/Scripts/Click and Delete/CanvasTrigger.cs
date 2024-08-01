using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{

    public GameObject canvas2;

    public GameObject camera2;

    private bool openUpAllowed;

    void OnEnable()
    {
        EventDispatcher.AddListener<ClickCollectedEvent>(ctx => Close());
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<ClickCollectedEvent>(ctx => Close());
    }
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
    }
    private void Close()
    {
        if (gameObject == null || !gameObject.activeInHierarchy) return;

        canvas2.SetActive(false);
        camera2.SetActive(false);
        GetComponent<CanvasTrigger>().enabled = false;
    }
}
