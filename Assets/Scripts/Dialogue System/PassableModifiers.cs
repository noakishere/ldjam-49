using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassableModifiers
{
    [SerializeField] private string modifierName;
    public string ModifierName
    {
        get { return modifierName; }
    }

    [SerializeField] private int modifierAmount;
    public int ModifierAmount
    {
        get { return modifierAmount; }
    }
}
