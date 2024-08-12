using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;
public class MenuButton : MonoBehaviour
{
    [SerializeField] string _clickClipName = "";
    [SerializeField] SceneReference scene = null;
    public void LoadScene()
    {
        if (SceneManager.GetSceneByName(scene.Name).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            return;
        }

        SceneManager.LoadScene(scene.Name);
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
