using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    int piecesCollected = 0; // * Keeps count of all the pieces that have been collected
    public TMP_Text counterText; // * Text UI that shows how many pieces were collected
    public GameObject keyIcon = null; // * Key UI Animation
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
        piecesCollected++;
        counterText.text = piecesCollected + "/6";

        switch (piecesCollected)
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

        if (piecesCollected == 6)
        {
            LoadPuzzleEvent loadPuzzleEvent = new LoadPuzzleEvent { loaded = true };
            EventDispatcher.Raise(loadPuzzleEvent);
            piecesCollected = 0;
        }
    }
    // * Enables Key UI after key is collected
    void ShowKeyIcon()
    {
        if (keyIcon == null) return;

        keyIcon.SetActive(true);
    }

    // * Disables Key UI after key is collected
    void HideKeyIcon()
    {
        if (keyIcon == null) return;

        keyIcon.SetActive(false);
    }

    //* Fires Events to VideoManager to play a comic cutscene after piece was collected
    void PlayComicVideo(string name)
    {
        GameVariables.Instance.SetComicToLoad(name);
        EventDispatcher.Raise(new LoadVideoComics { });
        EventDispatcher.Raise(new ChangeActionMapEvent { newActionMap = "Disable" }); // * Changes action map so input is diabled during cutscenes
    }
}
