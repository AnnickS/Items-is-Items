using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueIfAnyLoadButton : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        continueButton.interactable = StorageManager.IfAny();
    }

    public void Load()
    {
        StorageManager.PrepLoad();
    }
}
