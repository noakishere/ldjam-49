using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] private TMP_Text dialogueContainer;
    [SerializeField] private TMP_Text nameContainer;
    [SerializeField] private TMP_Text moodContainer;
    [SerializeField] private TMP_Text jobContainer;
    [SerializeField] private Image avatarContainer;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private GameObject continueButtonContainer;

    private void Start() 
    {

    }

    private Dialogue currentProcessDialogue;

    public void ProcessDialogueToUI(Dialogue dialogue)
    {
        currentProcessDialogue = dialogue;
        
        ProcessOptions();
        SetAvatar();
        SetDialogue();
        SetName();
        SetJob();
        SetMood();
    }

    public void SetAvatar()
    {
        avatarContainer.sprite = currentProcessDialogue.Character.Avatar;
    }
    public void SetDialogue()
    {
        dialogueContainer.text = currentProcessDialogue.Text;
    }

    public void SetMood()
    {
        moodContainer.text = $"Mood: {currentProcessDialogue.Character.InitialMood}";
    }
    public void SetName()
    {
        nameContainer.text = $"Name: {currentProcessDialogue.Character.Name}";
    }
    public void SetJob()
    {
        jobContainer.text = $"Job: {currentProcessDialogue.Character.Job}";
    }

    public void ProcessOptions()
    {
        if(currentProcessDialogue.Options.Length != 0)
        {
            Debug.Log($"Not empty options dude {currentProcessDialogue.Options.Length}");
            optionsContainer.SetActive(true);
            continueButtonContainer.SetActive(false);
            // do something
        }
        else
        {
            Debug.Log($"It's empty {currentProcessDialogue.Options.Length}");
            optionsContainer.SetActive(false);
            continueButtonContainer.SetActive(true);
        }
    }

}
