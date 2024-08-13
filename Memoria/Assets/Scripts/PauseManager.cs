using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;

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
            changeActionMap = new ChangeActionMapEvent { newActionMap = "Pause" };
        else
            changeActionMap = new ChangeActionMapEvent { newActionMap = "Player" };

        EventDispatcher.Raise(changeActionMap);
    }
}
