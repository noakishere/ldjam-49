using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : SingletonMonoBehaviour<GameEvents>
{
    public event Action onGoldChangeTrigger;
    public void GoldChangeTrigger()
    {
        if (onGoldChangeTrigger != null)
        {
            onGoldChangeTrigger();
        }
    }
}
