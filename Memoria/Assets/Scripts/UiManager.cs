using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class UiManager : MonoBehaviour
{
    private List<Collectable> _collectables = new();
    [SerializeField] private Canvas UICanvas = null;
    [SerializeField] TMP_Text collectableTextUI = null;

    int score = 0;
    int count = 0;

    void OnEnable()
    {
        EventDispatcher.AddListener<LoadPuzzleEvent>(OnPuzzleLoaded);
        // TODO EventDispatcher.AddListener<CollectedEvent>(ctx => AddScore());
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadPuzzleEvent>(OnPuzzleLoaded);
        // TODO EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddScore());
    }
    // void Start()
    // {
    //     count = _collectables.Count;
    //     collectableTextUI.text = $"Memories Collected {score}/{count}";
    // }

    // void AddScore()
    // {
    //     score++;
    //     collectableTextUI.text = $"Memories Collected {score}/{count}";
    // }

    void OnPuzzleLoaded(LoadPuzzleEvent evt)
    {
        EnableUI(!evt.loaded);
    }
    void EnableUI(bool enable)
    {
        if (UICanvas == null) return;

        UICanvas.gameObject.SetActive(enable);
    }
}
