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

            ProcessDialogueToUI(currentDialogue);
        }
    }
    

    public void ProcessDialogueToUI(Dialogue dialogue)
    {
        // This needs to be cleaned. Best thing is to move all the ui stuff to one function in UIManager i think.
        Sprite avatar = dialogue.Character.Avatar;
        UIManager.Instance.SetAvatar(avatar);
        UIManager.Instance.SetDialogue(dialogue);
        UIManager.Instance.SetName(dialogue);
        UIManager.Instance.SetJob(dialogue);
        UIManager.Instance.SetMood(dialogue);
    }
}



