using UnityEngine;

public class CanvasTrigger : Interactable
{

    public GameObject canvas2;

    public GameObject camera2;

    private void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            Close();
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

    public override void Interact()
    {
        OpenUp();
    }
}
