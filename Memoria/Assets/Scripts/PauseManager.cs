using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private Button mainButton;

    void OnEnable()
    {
        EventDispatcher.AddListener<GamePausedEvent>(LoadPauseMenu);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<GamePausedEvent>(LoadPauseMenu);
    }

    void LoadPauseMenu(GamePausedEvent evt)
    {
        LoadPauseMenu(evt.isPaused);
    }
    public void LoadPauseMenu(bool pause)
    {
        if (pauseMenu == null) return;

        ChangeActionMapEvent changeActionMap = new ChangeActionMapEvent();

        pauseMenu.SetActive(pause);

        if (pause)
        {
            changeActionMap = new ChangeActionMapEvent { newActionMap = "Pause" }; // * Changes Input Action Map so Player doesn't move when pause menu is active
            mainButton.Select();
        }
        else
            changeActionMap = new ChangeActionMapEvent { newActionMap = "Player" }; // * Changes Input Action Map back so player can move again

        EventDispatcher.Raise(changeActionMap);
    }
}
