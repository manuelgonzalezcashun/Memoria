using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _mainButton;
    void OnEnable()
    {
        _mainButton.Select();
    }
}
