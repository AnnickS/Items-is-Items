using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManagerSaveComponent : MonoBehaviour
{

    public void Save()
    {
        StorageManager.SaveGameData();
    }
}
