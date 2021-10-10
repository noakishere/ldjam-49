using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameVariable
{

    [SerializeField] private string varName;
    public string VarName 
    {
        get { return varName; }
        set { varName = value; }
    }
    [SerializeField] private int varAmount;
    public int VarAmount 
    {
        get { return varAmount; }
        set { varAmount = value; }
    }

    public GameVariable(string name, int amt)
    {
        varName = name;
        varAmount = amt;
    }
}
