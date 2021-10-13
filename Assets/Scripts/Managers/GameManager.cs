using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("Variable Controllers")]
    public List<GameVariable> gameVariables; // Holds all the variables inside

    // [Header("Holding Characters")]
    // public List<Character> charactersList; // List takes all the characters in the scene to further control their stats DO WE REALLY NEED THIS?? WE'LL SEE

    private void Start() 
    {
        
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F))
            Debug.Log(gameVariables.Find(x => x.VarName == "Gold").VarAmount);

    }

    // private void PopulateCharacterList()
    // {
    //     charactersList = new List<Character>();
    //     Character[] charactersInTheGame = FindObjectsOfType<Character>();
    //     foreach(Character character in charactersInTheGame)
    //     {
    //         charactersList.Add(character);
    //     }
    // }

    // These are not necessary to keep until the end, but a good idea to hold around for the moment
    #region Resource methods
    public void GoldChange(int amount)
    {
        // int currentGold = gameVariables.Find(x => x.VarName == "Gold").VarAmount;
        gameVariables.Find(x => x.VarName == "Gold").VarAmount += amount;
        UIManager.Instance.SetGold(gameVariables.Find(x => x.VarName == "Gold").VarAmount);
    }
    public void WoodChange(int amount)
    {
        // int currentGold = gameVariables.Find(x => x.VarName == "Gold").VarAmount;
        gameVariables.Find(x => x.VarName == "").VarAmount += amount;
        UIManager.Instance.SetWood(gameVariables.Find(x => x.VarName == "Wood").VarAmount);
    }
    public void ClothChange(int amount)
    {
        // int currentGold = gameVariables.Find(x => x.VarName == "Gold").VarAmount;
        gameVariables.Find(x => x.VarName == "Cloth").VarAmount += amount;
        UIManager.Instance.SetCloth(gameVariables.Find(x => x.VarName == "Cloth").VarAmount);
    }
    public void MeatChange(int amount)
    {
        // int currentGold = gameVariables.Find(x => x.VarName == "Gold").VarAmount;
        gameVariables.Find(x => x.VarName == "Meat").VarAmount += amount;
        UIManager.Instance.SetMeat(gameVariables.Find(x => x.VarName == "Meat").VarAmount);
    }

    #endregion


}
