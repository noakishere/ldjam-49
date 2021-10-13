using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Character : MonoBehaviour
{
    [Header("Character Details UI Controllers")]
    [SerializeField] private GameObject playerCanvasHolder;
    [SerializeField] private TMP_Text characterNameContainer;

    [Header("Character Details")]
    [SerializeField] private string characterMood;

    [Range(-10,10)]
    [SerializeField] private int relationWithPlayer;
    public int RelationWithPlayer { get {return relationWithPlayer;} }
    [SerializeField] private string characterAvatar;

    [SerializeField] private CharacterSO characterSO;

    [Header("Dialogue Variables")]
    [SerializeField] private DialogueQueueManager characterDialogueQueueManager;

    [SerializeField] private DialogueSO dialogueToPlay; // For now only one test dialogue.. but later will need a dialogue database for each character to correctly spread it lol

    [SerializeField] private int dialogueIndex;

    void Start()
    {
        dialogueIndex = 0;
        characterNameContainer.text = characterSO.Name;
        playerCanvasHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() 
    {
        DialogueManager.Instance.currentDialogueList = characterDialogueQueueManager.PassTheNextDialogue(dialogueIndex);
        dialogueIndex++;
        DialogueManager.Instance.PassDialogueToUI(); // Need to fix some shit in DialogueManager and UIManager to make it clean
        UIManager.Instance.CharacterUIContainer.SetActive(true);
    }

    private void OnMouseOver() 
    {
        playerCanvasHolder.SetActive(true);
    }

    private void OnMouseExit() 
    {
        playerCanvasHolder.SetActive(false);
    }
}
