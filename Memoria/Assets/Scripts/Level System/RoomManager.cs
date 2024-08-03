using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen = null;
    [SerializeField] SceneReference _roomToLoad = null;
    private string _currentRoom = string.Empty;
    void OnEnable()
    {
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => StartCoroutine(LoadingScreen(ctx.endSceneName)));
        EventDispatcher.AddListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
        DontDestroyOnLoad(this);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => StartCoroutine(LoadingScreen(ctx.endSceneName)));
        EventDispatcher.RemoveListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void Start()
    {
        if (_roomToLoad != null)
        {
            LoadRoom(_roomToLoad.Name);
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