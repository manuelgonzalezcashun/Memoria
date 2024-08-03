using System;
using UnityEngine;

public class CanvasTrigger : Interactable
{

    public GameObject canvas2;
    public GameObject camera2;
    private bool dialogueIsPlaying = false;

    void Awake()
    {
        EventDispatcher.AddListener<ShowDialogueEvent>(ctx => CheckForDialogue(ctx.showDialogueUI));
    }



    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
    private void OpenUp()
    {
        canvas2.SetActive(true);
        camera2.SetActive(true);
    }
    private void Close()
    {
        if (dialogueIsPlaying) return;

        canvas2.SetActive(false);
        camera2.SetActive(false);
    }
    private void CheckForDialogue(bool dialogue)
    {
        dialogueIsPlaying = dialogue;
    }

    public override void Interact()
    {
        OpenUp();
    }
}
