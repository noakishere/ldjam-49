using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
{

    // Dialogue Stuff
    [SerializeField] private DialogueSO currentDialogueList;
    public Dialogue currentDialogue;

    [SerializeField] private float typingSpeed;

    [SerializeField] private DialogueStates currentState;

    private int dialogueIndex;

   private void Start() 
   {
       dialogueIndex = 0;
       currentState = DialogueStates.Waiting;
       Debug.Log(currentDialogueList);
   }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // currentState = DialogueStates.Talking;
            currentDialogue = currentDialogueList.Dialogues[dialogueIndex];
            dialogueIndex++;
            UIManager.Instance.ProcessDialogueToUI(currentDialogue);
        }
    }

    
}



