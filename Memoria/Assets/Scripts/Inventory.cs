using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    int pieceCount = 0;
    public TMP_Text counterText;
    public Animator animator;
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
        animator.SetTrigger("Burst");
        ///if (pieceCount == 3)
        ///{
        ///EventDispatcher.Raise(new LoadSceneEvent { sceneToLoad = "Video Scene" });
        ///}

        if (pieceCount == 6)
        {
            EventDispatcher.Raise(new LoadSceneEvent { sceneToLoad = "Puzzle Scene" });
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
}
