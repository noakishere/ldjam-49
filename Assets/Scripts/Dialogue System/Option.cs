using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option
{
    [SerializeField] private string text;
    public string Text
    {
        get { return text; }
    }

    // This might need to be changed
    [SerializeField] private string affectModifier;
    public string AffectModifier
    {
        get { return affectModifier; }
    }

    [Tooltip("Be mindful of the Min and Max rules")]
    [SerializeField] private float amount;
    public float ModifierChangeAmount
    {
        get { return amount; }
    }

    [SerializeField] private PassableModifiers[] passableModifiers;
    public PassableModifiers[] PassableModifiers
    {
        get { return passableModifiers; }
    }

    private void OnChoose()
    {
        Debug.Log($"I got chosen!");
        GameEvents.Instance.GoldChangeTrigger();
    }
}
