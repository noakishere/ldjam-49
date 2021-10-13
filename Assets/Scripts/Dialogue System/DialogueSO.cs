using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueSO", order = 1)]
public class DialogueSO : ScriptableObject {
    [SerializeField] private List<Dialogue> dialogues;

    public List<Dialogue> Dialogues
    { 
        get { return dialogues; } 
    }
}