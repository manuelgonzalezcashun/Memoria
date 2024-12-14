using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI; // For UI.Text (or using TMPro for TextMeshPro)
using TMPro;

public class InkDialogueManager : MonoBehaviour
{
    #region Singleton Data
    private static InkDialogueManager _instance = null;
    public static InkDialogueManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("InkDialogueManager").AddComponent<InkDialogueManager>();
            }
            return _instance;
        }
    }
    #endregion

    Story _inkStory = null;
    private string sentence = string.Empty;
    private string _loadedState = string.Empty;

    private InkDialogueObserver observer = new();
    private InkExternalFunctions inkExternalFunctions = new();
    private InkTagHandler tagHandler = new();

    private Coroutine displayLineCoroutine;

    [SerializeField] private float typingSpeed = 0.04f; // Speed of typing effect
    [SerializeField] private TMP_Text dialogueText; // Reference to the UI Text component

    // Method to load the Ink story
    public void LoadStory(TextAsset storyJSON)
    {
        _inkStory = new Story(storyJSON.text);
        observer.ObserveInkVariables(_inkStory);
        // TODO inkExternalFunctions.Bind(_inkStory);
    }

    // Display the next line of dialogue
    public void DisplayNextLine()
    {
        if (_inkStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(_inkStory.Continue()));
            EventDispatcher.Raise(new ContinueDialogueEvent { dialogueLine = sentence });
        }
        else if (!_inkStory.canContinue)
        {
            EndStory();
        }

        // TODO tagHandler.HandleTags(_inkStory.currentTags);
    }

    // End the story
    private void EndStory()
    {
        _inkStory = null;
        sentence = string.Empty;

        EventDispatcher.Raise(new ShowDialogueEvent { showDialogueUI = false });
        // TODO inkExternalFunctions.Unbind(_inkStory);
    }

    // Coroutine to display the line with typewriter effect
    private IEnumerator DisplayLine(string line)
    {
        sentence = ""; // Reset sentence before typing new line
        dialogueText.text = ""; // Clear existing text in the UI

        foreach (char letter in line.ToCharArray())
        {
            sentence += letter; // Add the next letter to the sentence
            dialogueText.text = sentence; // Update the UI text to show current sentence
            yield return new WaitForSeconds(typingSpeed); // Wait for typing speed
        }
    }
}
