using UnityEngine;
using TMPro; // For TextMeshPro
using System.Collections;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText = null; // Reference to the TMP_Text component
    [SerializeField] GameObject dialogueContainer = null; // Reference to the dialogue container (UI panel)

    private Coroutine typingCoroutine = null; // Reference to the coroutine for typing effect
    [SerializeField] private float typingSpeed = 0.05f; // Speed of the typing effect (time between characters)
    private bool submitButtonPressed = false;

    void OnEnable()
    {
        // Subscribe to the events
        EventDispatcher.AddListener<ShowDialogueEvent>(ShowDialogueText);
        EventDispatcher.AddListener<ContinueDialogueEvent>(StepThroughDialogue);
    }

    void OnDisable()
    {
        // Unsubscribe from the events
        EventDispatcher.RemoveListener<ShowDialogueEvent>(ShowDialogueText);
        EventDispatcher.RemoveListener<ContinueDialogueEvent>(StepThroughDialogue);
    }

    // Method to show or hide the dialogue container
    void ShowDialogueText(ShowDialogueEvent evt)
    {
        dialogueContainer.SetActive(evt.showDialogueUI); // Show/hide the dialogue UI based on the event
        if (!evt.showDialogueUI)
        {
            dialogueText.text = string.Empty; // Clear the text when hiding the dialogue
        }
    }

    // Method to trigger the typewriter effect when a new line is displayed
    void StepThroughDialogue(ContinueDialogueEvent evt)
    {
        // If there is an existing coroutine running (if text is already typing), stop it
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        // Start the typewriter effect coroutine
        typingCoroutine = StartCoroutine(TypewriterEffect(evt.dialogueLine));
    }

    // Coroutine that handles the typewriter effect
    private IEnumerator TypewriterEffect(string dialogueLine)
    {
        dialogueText.text = ""; // Clear any existing text

        // Loop through each character in the line
        foreach (char letter in dialogueLine)
        {
            dialogueText.text += letter; // Add the next letter to the text
            yield return new WaitForSeconds(typingSpeed); // Wait for the typing speed before showing the next letter
        }
    }
}

