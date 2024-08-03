using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Camera puzzleCamera = null;
    [SerializeField] private Canvas puzzleCanvas = null;
    [SerializeField] private List<Puzzle> puzzles = new List<Puzzle>();

    void OnEnable()
    {
        EventDispatcher.AddListener<LoadSceneEvent>(ctx => EnablePuzzle(true));
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => EnablePuzzle(false));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadSceneEvent>(ctx => EnablePuzzle(true));
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => EnablePuzzle(false));
    }

    public void EnablePuzzle(bool enable)
    {
        puzzleCamera.gameObject.SetActive(enable);
        puzzleCanvas.gameObject.SetActive(enable);
    }
}
