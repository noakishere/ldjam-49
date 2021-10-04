using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private int goldAmt;
    public int GoldAmount
    {
        get { return goldAmt; }
    }

    public void GoldChange(int amount)
    {
        goldAmt += amount;
        UIManager.Instance.SetGold(goldAmt);
    }


}
