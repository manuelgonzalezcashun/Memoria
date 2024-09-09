using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject page = null; // * Settings Panels in Main Menu

    // * Enables or Disables pages that are in the Settings Menu
    public void EnablePage()
    {
        page.SetActive(!page.activeSelf);
    }
}
