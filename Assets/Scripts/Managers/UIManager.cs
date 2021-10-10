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

    private Dialogue currentProcessDialogue;

    private void Start() 
    {
        SetGold(GameManager.Instance.gameVariables.Find(x => x.VarName == "Gold").VarAmount);
        SetWood(GameManager.Instance.gameVariables.Find(x => x.VarName == "Wood").VarAmount);
        SetCloth(GameManager.Instance.gameVariables.Find(x => x.VarName == "Cloth").VarAmount);
        SetMeat(GameManager.Instance.gameVariables.Find(x => x.VarName == "Meat").VarAmount);
    }

    public void ProcessDialogueToUI(Dialogue dialogue)
    {
        currentProcessDialogue = dialogue;
        
        // ProcessOptions();
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

        // To prevent showing options before the text is done.
        TurnOffContinueButton();
        TurnOffAllOptions();

        dialogueContainer.text = currentProcessDialogue.Text;
        ProcessOptions();


        // DialogueManager.Instance.SetDialogueState(DialogueStates.Waiting);
        
        // StartCoroutine(AutoTypeText());
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
                // TurnOnOptions() is because if in a previous case, options were totally off, we turn them all back on and then turn off the unwanted ones.. Iknow it's sloppy
                // Will have to rework it later.
                TurnOnOptions(); 
                TurnOffOptions();
            }

            // Enables them if they were disabled
            else
            {
                TurnOnOptions();
            }

            for(int i = 0; i < optionsLength; i++) // To adjust the options text
            {                
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
            Debug.Log($"Option's empty {currentProcessDialogue.Options.Length}");
            optionsContainer.SetActive(false);
            continueButtonContainer.SetActive(true);
        }
    }

    public void TurnOnOptions()
    {
        for(int i = 0; i < optionsContainer.transform.childCount; i++)
        {
            optionsContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void TurnOffOptions()
    {
        Debug.Log($"Options number after being disabled before?  {optionsContainer.transform.childCount}");
        for(int i = currentProcessDialogue.Options.Length; i < optionsContainer.transform.childCount; i++)
        {
            optionsContainer.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void TurnOffAllOptions()
    {
        for(int i = 0; i < optionsContainer.transform.childCount; i++)
        {
            optionsContainer.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void TurnOffContinueButton()
    {
        continueButtonContainer.SetActive(false);
    }

    #region Player UI Details Set Methods
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
    #endregion



    // For now not used. I don't think it suits the project for now.
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

        // To prevent the spam kids
        yield return new WaitForSeconds(waitBeforeNextDialogueSpeed * Time.deltaTime);
        DialogueManager.Instance.SetDialogueState(DialogueStates.Waiting);
        ProcessOptions();
        
        // TODO: MID TYPING INTERRUPT WILL FUCK UP THE DIALOGUE SHOWN
        // It's better than now, but can be better you know. GE!
    }
}
