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

    public void SetAvatar(Sprite avatar)
    {
        avatarContainer.sprite = avatar;
    }
    public void SetDialogue(Dialogue dialogue)
    {
        dialogueContainer.text = dialogue.Text;
    }

    public void SetMood(Dialogue dialogue)
    {
        moodContainer.text = $"Mood: {dialogue.Character.InitialMood}";
    }
    public void SetName(Dialogue dialogue)
    {
        nameContainer.text = $"Name: {dialogue.Character.Name}";
    }
    public void SetJob(Dialogue dialogue)
    {
        jobContainer.text = $"Mood: {dialogue.Character.Job}";
    }

}
