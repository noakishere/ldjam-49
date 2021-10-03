using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
{

    // Dialogue Stuff
    [SerializeField] private DialogueSO currentDialogueList;
    public Dialogue currentDialogue;

    [SerializeField] private float typingSpeed;

    //[SerializeField] private DialogueStates currentState;

   private void Start() 
   {
       Debug.Log(currentDialogueList);
   }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentDialogue = currentDialogueList.Dialogues[0];

            UIManager.Instance.ProcessDialogueToUI(currentDialogue);
        }
    }

    
}



