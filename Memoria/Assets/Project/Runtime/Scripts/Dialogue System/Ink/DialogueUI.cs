using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText = null;
    [SerializeField] GameObject dialogueContainer = null;

    void OnEnable()
    {
        EventDispatcher.AddListener<ShowDialogueEvent>(ShowDialogueText);
        EventDispatcher.AddListener<ContinueDialogueEvent>(StepThroughDialogue);

    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<ShowDialogueEvent>(ShowDialogueText);
        EventDispatcher.RemoveListener<ContinueDialogueEvent>(StepThroughDialogue);

    }
    void ShowDialogueText(ShowDialogueEvent evt)
    {
        dialogueContainer.SetActive(evt.showDialogueUI);
        dialogueText.text = string.Empty;
    }
    void StepThroughDialogue(ContinueDialogueEvent evt)
    {
        dialogueText.text = evt.dialogueLine;
    }
}
