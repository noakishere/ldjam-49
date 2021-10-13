using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
{
    // Dialogue Stuff
    [Header("Dialogue Section")]
    [SerializeField] public DialogueSO currentDialogueList;
    public Dialogue currentDialogue;
    
    [Tooltip("Must never be more than the options' length")]
    [SerializeField] private int dialogueIndex;

    public PassableModifiers[,] currentDialogueOptions { get; private set; }


    [Header("Modify Dialogue State")]
    [SerializeField] private DialogueStates currentState;
    public DialogueStates CurrentState
    {
        get { return currentState; }
    }
    public void SetDialogueState(DialogueStates state)
    {
        currentState = state;
    }

    private void Start() 
    {
        dialogueIndex = 0; 
        currentState = DialogueStates.Waiting;

        currentDialogueOptions = new PassableModifiers[3,3];

        Debug.Log(currentDialogueList);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) /*&& currentState == DialogueStates.Waiting*/)
        {
            // ONLY FOR TESTING PURPOSES, THIS WILL NEED TO BE CLEANED AFTER
            if(dialogueIndex == currentDialogueList.Dialogues.Count)
            {
                dialogueIndex = 0;
                PassDialogueToUI();
            }
            else
            {
                PassDialogueToUI();
            }
        }
    }

    public void PassDialogueToUI()
    {
        currentDialogue = currentDialogueList.Dialogues[dialogueIndex];
        dialogueIndex++;
        UIManager.Instance.ProcessDialogueToUI(currentDialogue);

        // We don't really need states if we change text without autotype.. -> to fix
        // Debug.Log("I'm messing with you :P");
        // currentState = DialogueStates.Talking;
    }

    public void SetDialogueIndexZero()
    {
        dialogueIndex = 0;
    }
}