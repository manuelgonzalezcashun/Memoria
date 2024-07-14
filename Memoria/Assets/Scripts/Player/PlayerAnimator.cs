using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Dictionary<string, AnimationClip> m_playerAnims = new();
    private Animator playerAnimator = null;
    private string _state = string.Empty;

    [SerializeField] private List<PlayerAnimations> playerAnimations = new();

    void OnEnable()
    {
        playerAnimator = GetComponent<Animator>();

        EventDispatcher.AddListener<ChangeAnimStateEvent>(ChangeAnimState);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<ChangeAnimStateEvent>(ChangeAnimState);
    }
    void Awake()
    {
        foreach (var clips in playerAnimations)
        {
            if (playerAnimations.Count > 0)
            {
                m_playerAnims.Add(clips._name, clips._clip);
            }
        }
    }
    void ChangeAnimState(ChangeAnimStateEvent evt)
    {
        ChangeAnimState(evt._state);
    }
    void ChangeAnimState(string name)
    {
        if (m_playerAnims.ContainsKey(name))
        {
            _state = name;
            playerAnimator.Play(m_playerAnims[_state].name);
        }
        else
        {
            Debug.LogWarning($"Could not find {name} in list of animation clips");
        }
    }
}

[System.Serializable]
public class PlayerAnimations
{
    public string _name;
    public AnimationClip _clip;
}
