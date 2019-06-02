using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Combination[] combinations;

    private void Awake()
    {
        Instance = this;
        Descriptor.PrintDescriptorTree();
        combinations = GetCombinations();
        Debug.Log(combinations.Length);

        StorageManager.ExecuteLoadIfAny();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Saving...");
            StorageManager.SaveGameData();
            Debug.Log("Saved.");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Loading...");
            StorageManager.PrepLoad();            
        }
    }

    public void SpawnItem(GameObject itemPrefab, Vector3 position, Quaternion rotation)
    {
        GameObject newItem = Instantiate(itemPrefab, position, rotation);
        newItem.GetComponent<Item>().itemBaseName = itemPrefab.name;
    }

    public bool ExecuteInteraction(Item item1, Item item2)
    {
        Debug.Log("Executing interaction... item 1: " + item1.name + " item 2: " + item2.name);
        bool interacted = false;
        foreach (Combination combination in combinations)
        {
            if (combination.IsInitialized())
            {
                if (combination.IsMatch(item1, item2))
                {
                    combination.Execute(item1, item2);
                    interacted = true;
                }
                else if (combination.IsMatch(item2, item1))
                {
                    combination.Execute(item2, item1);
                    interacted = true;
                }
            }
        }
        return interacted;
    }

    public Item GetItemByNickname(String name)
    {
        foreach(Item item in GameObject.FindObjectsOfType<Item>())
        {
            if(item.name == name)
            {
                return item;
            }
        }
        throw new Exception("Item name not found!");
    }

    public Combination[] Load()
    {
        combinations = Resources.LoadAll<Combination>("Combinations");
        return combinations;
    }

    public Combination[] GetCombinations()
    {
        if (combinations == null)
        {
            Load();
        }
        return combinations;
    }    
}
