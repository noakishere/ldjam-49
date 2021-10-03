using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Dialogue Stuff
    [SerializeField] private DialogueSO currentDialogueList;
    public Dialogue currentDialogue;

    [SerializeField] private float typingSpeed;

    //[SerializeField] private DialogueStates currentState;
    
   void Start()
   {
        Debug.Log(currentDialogueList);

       // if(currentDialogueList != null)
         //   ProcessDialogue(currentDialogueList.Dialogues[0]);
   }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && currentDialogueList != null)
        {
            currentDialogue = currentDialogueList.Dialogues[0];

            ProcessDialogue(currentDialogue);
        }
    }
    

    public void ProcessDialogue(Dialogue dialogue)
    {
        Sprite avatar = dialogue.Character.Avatar;
        FindObjectOfType<UIManager>().SetAvatar(avatar);
    }
}



