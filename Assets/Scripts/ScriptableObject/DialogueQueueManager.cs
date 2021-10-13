using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogueQueueManager", menuName = "ScriptableObjects/DialogueQueueManager", order = 0)]
public class DialogueQueueManager : ScriptableObject
{
    [SerializeField] private CharacterSO character;
    [SerializeField] private List<DialogueSO> dialogues;

    public DialogueSO PassTheNextDialogue(int index)
    {
        if (index >= dialogues.Count)
            return null;

        else
            return dialogues[index];
    }
}
