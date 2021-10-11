using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassableModifiers
{

    /* This could change to a state thing to better control the design */
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
