using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{

    public GameObject DoorTrigger;

    public GameObject Puzzletrigger;

    public GameObject Camera;

    public GameObject MainCamera;

    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Door")
        {
            Puzzletrigger.SetActive(true);
            Camera.SetActive(true);
            MainCamera.SetActive(false);
            canvas.SetActive(false);
        }
    }
}
