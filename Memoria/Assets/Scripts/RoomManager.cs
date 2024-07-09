using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen = null;
    private string _currentScene = string.Empty;
    void OnEnable()
    {
        EventDispatcher.AddListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadRoom("Puzzle Scene");
        }
    }
    void LoadRoom(string sceneName)
    {
        UnloadRoom();
        if (_currentScene != sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            _currentScene = sceneName;
        }
    }
    void UnloadRoom()
    {
        if (_currentScene == string.Empty) return;

        SceneManager.UnloadSceneAsync(_currentScene);

    }
    IEnumerator LoadingScreen(string sceneName)
    {
        UnloadRoom();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            yield return null;

            if (operation.isDone)
            {
                _currentScene = sceneName;
                loadingScreen.SetActive(false);
            }
        }

    }
}