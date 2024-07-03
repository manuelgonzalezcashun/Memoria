using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class UiManager : MonoBehaviour
{
    private List<Collectable> _collectables = new();
    public TMP_Text collectableTextUI = null;

    int score = 0;
    int count = 0;

    void OnEnable()
    {
        EventDispatcher.AddListener<CollectedEvent>(ctx => AddScore());
        EventDispatcher.AddListener<GetCollectableCount>(AddCollectable);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddScore());
        EventDispatcher.RemoveListener<GetCollectableCount>(AddCollectable);
    }
    void Start()
    {
        count = _collectables.Count;
        collectableTextUI.text = $"Memories Collected {score}/{count}";
    }

    void AddScore()
    {
        score++;
        collectableTextUI.text = $"Memories Collected {score}/{count}";
    }
    void AddCollectable(GetCollectableCount evt)
    {
        _collectables.Add(evt.collectable);
    }
}
