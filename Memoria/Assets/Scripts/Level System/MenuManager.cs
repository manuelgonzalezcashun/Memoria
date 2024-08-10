using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;
public class MenuManager : MonoBehaviour
{
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

    // * When player loads MainMenu, Reset all the data in GameVariables class
    public void ResetGameVaraibles()
    {
        GameVariables.Instance.ResetValues();
        Debug.Log("Reset Variables");
    }
}
