using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    private string _currentScene = string.Empty;
    void OnEnable()
    {
        EventDispatcher.AddListener<LoadRoomEvent>(ctx => LoadRoom(ctx.roomName));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadRoomEvent>(ctx => LoadRoom(ctx.roomName));
    }
    void Awake()
    {
        LoadRoom("Room 1");
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
}
