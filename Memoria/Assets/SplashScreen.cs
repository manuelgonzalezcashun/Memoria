using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] VideoPlayer player;

    void Awake()
    {
        player.url = Application.streamingAssetsPath + "/GH_SPLASH_FINAL.webm";
        player.loopPointReached += FinishedVideo;
    }
    void Start()
    {
        player.Play();
    }

    private void FinishedVideo(VideoPlayer player)
    {
        SceneManager.LoadScene(1);
    }
}
