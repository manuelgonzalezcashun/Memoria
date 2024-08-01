using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateMachine : MonoBehaviour
{
    private Dictionary<string, AnimationClip> m_playerAnims = new();
    private Animator playerAnimator = null;
    private string _state = string.Empty;

    [SerializeField] private List<AnimClipStates> animClips = new();
    [SerializeField] private bool playOnAwake = false;

    void OnEnable()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Awake()
    {
        foreach (var clips in animClips)
        {
            if (animClips.Count > 0)
            {
                m_playerAnims.Add(clips._name, clips._clip);
            }
        }
    }
    void Start()
    {
        if (playOnAwake)
        {
            ChangeAnimState(animClips[0]._name);
        }
    }
    public void ChangeAnimState(string name)
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
public class AnimClipStates
{
    public string _name;
    public AnimationClip _clip;
}
