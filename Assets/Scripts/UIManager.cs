using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /*private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }*/

    [SerializeField] private TMP_Text dialogueContainer;
    [SerializeField] private TMP_Text nameContainer;
    [SerializeField] private TMP_Text moodContainer;
    [SerializeField] private TMP_Text jobContainer;
    [SerializeField] private Image avatarContainer;


   // [SerializeField] private CharacterSO currentCharacter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAvatar(Sprite avatar)
    {
        avatarContainer.sprite = avatar;
    }
}
