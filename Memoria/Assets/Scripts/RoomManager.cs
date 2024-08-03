using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen = null;
    [SerializeField] string _roomToLoad = string.Empty;
    private string _currentRoom = string.Empty;
    void OnEnable()
    {
        EventDispatcher.AddListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
        DontDestroyOnLoad(this);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void Start()
    {
        if (_roomToLoad != string.Empty)
        {
            LoadRoom(_roomToLoad);
        }
    }
    void LoadRoom(string roomName)
    {
        if (_currentRoom != roomName)
        {
            SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
            _currentRoom = roomName;
        }
    }
    void UnloadCurrentRoom()
    {
        if (_currentRoom == string.Empty) return;

        SceneManager.UnloadSceneAsync(_currentRoom);
        _currentRoom = string.Empty;
    }
    void UnloadRoom(string roomName)
    {
        SceneManager.UnloadSceneAsync(roomName);
    }
    IEnumerator LoadingScreen(string roomName)
    {
        UnloadCurrentRoom();
        AsyncOperation operation = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            yield return null;

            if (operation.isDone)
            {
                _currentRoom = roomName;
                loadingScreen.SetActive(false);
            }
        }

    }
}