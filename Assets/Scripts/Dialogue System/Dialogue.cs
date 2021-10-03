using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(5,10)]
    [SerializeField] private string text;

    public string Text
    {
        get { return text; }
    }

    [SerializeField] private CharacterSO character;
    public CharacterSO Character
    {
        get { return character; }
    }

    [Header("If not required, leave empty")]
    [SerializeField] private Option[] options;
    public Option[] Options
    {
        get { return options; }
    }
}
