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

    [SerializeField] private PassableModifiers[] passableModifiers;
    public PassableModifiers[] PassableModifiers
    {
        get { return passableModifiers; }
    }

    // This function processes all the modifiers when the button is chosen and call GameManager for changes.
    public void OnChoose()
    {
        for(int i = 0; i < passableModifiers.Length; i++)
        {
            Debug.Log($"This changes option {GameManager.Instance.gameVariables.Find(x => x.VarName == passableModifiers[i].ModifierName).VarName}");
            GameManager.Instance.gameVariables.Find(x => x.VarName == passableModifiers[i].ModifierName).VarAmount += passableModifiers[i].ModifierAmount;
        }
        UIManager.Instance.UIChange();
    }
}
