using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterSO", order = 0)]
public class CharacterSO : ScriptableObject 
{
    [SerializeField] private string charName;
    public string Name 
    { 
        get { return charName; } 
    }

    [SerializeField] private string job;
    public string Job 
    { 
        get { return job; } 
    }

    [SerializeField] private string initialMood;
    public string InitialMood 
    {
        get 
        { return initialMood; } 
    }

    [SerializeField] private Sprite avatar;
    public Sprite Avatar
    {
        get
        { return avatar; }
    }
}
