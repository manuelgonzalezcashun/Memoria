using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Database", menuName = "Dialogue System / Create new Dialogue Database")]

public class DialogueDatabase : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private List<string> dialogueLines = new();
    public List<string> DialogueLines => dialogueLines;
}
