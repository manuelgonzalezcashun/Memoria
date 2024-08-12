using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Camera puzzleCamera = null;
    [SerializeField] private Canvas puzzleCanvas = null;
    [SerializeField] private List<Puzzle> puzzles = new List<Puzzle>();

    void OnEnable()
    {
        EventDispatcher.AddListener<LoadPuzzleEvent>(ctx => EnablePuzzle(ctx.loaded));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadPuzzleEvent>(ctx => EnablePuzzle(ctx.loaded));
    }

    public void EnablePuzzle(bool enable)
    {
        if (puzzleCamera == null || puzzleCanvas == null) return;

        puzzleCamera.gameObject.SetActive(enable);
        puzzleCanvas.gameObject.SetActive(enable);
    }
}
