using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onGoldChangeTrigger += OnGoldChange;
    }

    private void OnGoldChange()
    {
        GameManager.Instance.GoldChange(2);
    }
}
