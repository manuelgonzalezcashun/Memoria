using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    int pieceCount = 0;
    public TMP_Text counterText;
    public GameObject keyIcon = null;
    void OnEnable()
    {
        EventDispatcher.AddListener<CollectedEvent>(ctx => AddToCount());
        EventDispatcher.AddListener<KeyCollectedEvent>(ctx => ShowKeyIcon());
        EventDispatcher.AddListener<KeyUsedEvent>(ctx => HideKeyIcon());
        counterText.text = "0/6";
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddToCount());
        EventDispatcher.RemoveListener<KeyCollectedEvent>(ctx => ShowKeyIcon());
        EventDispatcher.RemoveListener<KeyUsedEvent>(ctx => HideKeyIcon());
    }
    void AddToCount()
    {
        pieceCount++;
        counterText.text = pieceCount + "/6";

        switch (pieceCount)
        {
            case 0:
                break;
            case 1:
                PlayComicVideo("Piece 1");
                break;
            case 2:
                PlayComicVideo("Piece 2");
                break;
            case 3:
                PlayComicVideo("Piece 3");
                break;
            case 4:
                PlayComicVideo("Piece 4");
                break;
            case 5:
                PlayComicVideo("Piece 5");
                break;
        }

        if (pieceCount == 6)
        {
            LoadPuzzleEvent loadPuzzleEvent = new LoadPuzzleEvent { loaded = true };
            EventDispatcher.Raise(loadPuzzleEvent);
            pieceCount = 0;
        }
    }
    void ShowKeyIcon()
    {
        if (keyIcon == null) return;

        keyIcon.SetActive(true);
    }
    void HideKeyIcon()
    {
        if (keyIcon == null) return;

        keyIcon.SetActive(false);
    }
    void PlayComicVideo(string name)
    {
        GameVariables.Instance.SetComicToLoad(name);
        EventDispatcher.Raise(new LoadVideoComics { });

    }
}
