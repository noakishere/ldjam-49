using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{

    [Header("Dialogue Type Section")]
    [SerializeField] private float autoTypeSpeed;
    [SerializeField] private float waitBeforeNextDialogueSpeed;

    [Header("Character UI Section")]
    [SerializeField] private TMP_Text dialogueContainer;
    [SerializeField] private TMP_Text nameContainer;
    [SerializeField] private TMP_Text moodContainer;
    [SerializeField] private TMP_Text jobContainer;
    [SerializeField] private Image avatarContainer;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private GameObject continueButtonContainer;

    [Header("Player UI Section")]
    [SerializeField] private TMP_Text goldAmountContainer;
    [SerializeField] private TMP_Text woodAmountContainer;
    [SerializeField] private TMP_Text clothAmountContainer;
    [SerializeField] private TMP_Text meatAmountContainer;
    [SerializeField] private TMP_Text villageMoodAmountContainer;

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
        dialogueContainer.text = "";
        StartCoroutine(AutoTypeText());
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

            int optionsLength = currentProcessDialogue.Options.Length;

            // Disables the unusable option buttons
            if (optionsLength < optionsContainer.transform.childCount)
            {
                for(int i = optionsLength; i < optionsContainer.transform.childCount; i++)
                {
                    optionsContainer.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            // Enables them if they were disabled
            else
            {
                for(int i = 0; i < optionsContainer.transform.childCount; i++)
                {
                    optionsContainer.transform.GetChild(i).gameObject.SetActive(true);
                }
            }

            for(int i = 0; i < optionsLength; i++) // To adjust the options text
            {
                Debug.Log(optionsContainer.transform.childCount);
                
                // To change the button's TMP Text to option's initial name
                string optionText = currentProcessDialogue.Options[i].Text;
                var toBeChanged = optionsContainer.transform.GetChild(i).GetComponentInChildren<TMP_Text>();

                toBeChanged.text = optionText;

                // To add a function to button's onClick
                /** MUST BE REWORKED IN CASE MODIFIER IS EMPTY **/
                Button btn = optionsContainer.transform.GetChild(i).GetComponent<Button>();
                int amountWeNeed = (int)currentProcessDialogue.Options[i].ModifierChangeAmount;
                btn.onClick.AddListener(delegate{GameManager.Instance.GoldChange(amountWeNeed);});
            }
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


    public void SetGold(int amount)
    {
        goldAmountContainer.text = $"Gold: {amount}";
    }
    public void SetVillageMood(int amount)
    {
        villageMoodAmountContainer.text = $"Village Mood: {amount}";
    }
    public void SetWood(int amount)
    {
        woodAmountContainer.text = $"Wood: {amount}";
    }
    public void SetMeat(int amount)
    {
        meatAmountContainer.text = $"Meat: {amount}";
    }
    public void SetCloth(int amount)
    {
        clothAmountContainer.text = $"Cloth: {amount}";
    }


    private IEnumerator AutoTypeText()
    {
        foreach(char letter in currentProcessDialogue.Text)
        {
            // If the player wants to complete the text bro and don't wanna wait for shit
            if(Input.GetKeyDown(KeyCode.S) && DialogueManager.Instance.CurrentState == DialogueStates.Talking)
            {
                dialogueContainer.text = currentProcessDialogue.Text;
                DialogueManager.Instance.SetDialogueState(DialogueStates.Waiting);
                break; // this doesn't seem to always work?
            }
            dialogueContainer.text += letter;
            yield return new WaitForSeconds(autoTypeSpeed * Time.deltaTime);
        }

        yield return new WaitForSeconds(waitBeforeNextDialogueSpeed * Time.deltaTime);
        DialogueManager.Instance.SetDialogueState(DialogueStates.Waiting);
        
        // TODO: MID TYPING INTERRUPT WILL FUCK UP THE DIALOGUE SHOWN
        yield return null;
    }


}
