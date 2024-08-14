using UnityEngine;

public class Startburst : MonoBehaviour
{
    Animator animator = null;

    void Awake() => animator = GetComponent<Animator>();


    void OnEnable()
    {
        EventDispatcher.AddListener<CollectedEvent>(PlayStarBurst);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<CollectedEvent>(PlayStarBurst);
    }

    void PlayStarBurst(CollectedEvent evt)
    {
        animator.SetTrigger("Burst");
    }
}
