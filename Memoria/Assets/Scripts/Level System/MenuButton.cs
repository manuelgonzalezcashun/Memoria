using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    [SerializeField] SceneReference scene = null;
    private Button _currentbutton;

    const string _clickClipName = "Menu";

    void Start()
    {
        _currentbutton = GetComponent<Button>();

        _currentbutton.Select();
    }
    public void LoadScene()
    {
        if (SceneManager.GetSceneByName(scene.Name).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            return;
        }

        SceneManager.LoadScene(scene.Name);
    }

    public void UnloadVideoScene()
    {
        SceneManager.UnloadSceneAsync("Video Scene");
        EventDispatcher.Raise(new ChangeActionMapEvent { newActionMap = "Player" });
    }
    public void PlayClickSound()
    {
        if (_clickClipName == string.Empty) return;

        EventDispatcher.Raise(new PlaySoundEvent { _clipName = _clickClipName });
    }

    // * When player loads MainMenu, Reset all the data in GameVariables class
    public void ResetGameVaraibles()
    {
        GameVariables.Instance.ResetValues();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
