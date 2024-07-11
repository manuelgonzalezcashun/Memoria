using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen = null;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadRoom("Puzzle Scene");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UnloadRoom();
        }
    }
    void LoadRoom(string roomName)
    {
        UnloadRoom();
        if (_currentRoom != roomName)
        {
            SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

            _currentRoom = roomName;
        }
    }
    void UnloadRoom()
    {
        if (_currentRoom == string.Empty) return;

        SceneManager.UnloadSceneAsync(_currentRoom);
        _currentRoom = string.Empty;

    }
    IEnumerator LoadingScreen(string roomName)
    {
        UnloadRoom();
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