using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject page = null;

    public void EnablePage()
    {
        page.SetActive(!page.activeSelf);
    }
}
