﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StorageManager
{
    public const String SAVENAME = "OnlySave";
    private const String PREFABFILEPATH = "PreFabs";
    private static String FileToLoad;

    public static bool IfAny()
    {
        String path = Path.Combine(Application.persistentDataPath, SAVENAME + ".json");
        return File.Exists(path);
    }

    public static void SaveGameData()
    {
        String path = Path.Combine(Application.persistentDataPath, SAVENAME + ".json");
        Debug.Log(path);

        //new GameData(SceneManager.GetActiveScene().name); /*
        using (StreamWriter streamWriter = File.CreateText(path))
        {
            String json = JsonUtility.ToJson(new GameData());
            streamWriter.Write(json);
        }
        /**/
    }

    public static void PrepLoad()
    {
        String path = Path.Combine(Application.persistentDataPath, SAVENAME + ".json");
        if (File.Exists(path))
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonString = streamReader.ReadToEnd();
                GameData gameData = JsonUtility.FromJson<GameData>(jsonString);
                FileToLoad = SAVENAME;
                SceneManager.LoadScene(gameData.sceneBaseName);
            }
        }
    }

    public static void ExecuteLoadIfAny()
    {
        if (FileToLoad != null)
        {
            String path = Path.Combine(Application.persistentDataPath, FileToLoad + ".json");

            GameData gameData = null;
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonString = streamReader.ReadToEnd();
                gameData = JsonUtility.FromJson<GameData>(jsonString);
            }

            LoadGameData(gameData);
            FileToLoad = null;
            Debug.Log("Loaded.");
        }
        else
        {
            Debug.LogWarning("No file to load.");
        }
    }

    private static void LoadGameData(GameData gameData)
    {
        FileToLoad = null;
        if(gameData == null)
        {
            throw new FileNotFoundException();
        }

        foreach(ItemData item in gameData.items)
        {
            GameObject realItem = GameObject.Find(item.name);
            if(realItem == null)
            {
                if(String.IsNullOrEmpty(item.itemBaseName) == false)
                {
                    try
                    {
                        realItem = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(PREFABFILEPATH+"/Item/" + item.itemBaseName));
                        realItem.name = item.name;
                    }
                    catch(ArgumentException)
                    {
                        Debug.LogError("Failed to load '" + item.name+"': '" + item.itemBaseName + "' does not exist in ");
                    }
                }
                else
                {
                    Debug.LogWarning("Loading item '"+item.name+"' failed.");
                    continue;
                }
            }
            realItem.SetActive(!item.disabled);
            realItem.transform.position = new Vector3(item.position[0], item.position[1], realItem.transform.position.z);
            realItem.transform.rotation = new Quaternion(item.rotation[0], item.rotation[1], item.rotation[2], item.rotation[3]);
        }

        foreach(NPCItemData npc in gameData.npcs)
        {
            GameObject realNPC = GameObject.Find(npc.name);
            if (realNPC == null)
            {
                if (String.IsNullOrEmpty(npc.itemBaseName) == false)
                {
                    try { 
                        realNPC = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(PREFABFILEPATH+"/NPC/" + npc.itemBaseName));
                        realNPC.name = npc.name;
                    }
                    catch (ArgumentException)
                    {
                        Debug.LogError("Failed to load '" + npc.name + "': '" + npc.itemBaseName + "' does not exist in ");
                    }
                }
                else
                {
                    Debug.LogWarning("Loading item '" + npc.name + "' failed.");
                    continue;
                }
            }
            realNPC.transform.position = new Vector3(npc.position[0], npc.position[1], realNPC.transform.position.z);
            realNPC.transform.rotation = new Quaternion(npc.rotation[0], npc.rotation[1], npc.rotation[2], npc.rotation[3]);

            
            if (npc.questIndex != -1)
            {
                QuestGiver questContainer = realNPC.GetComponent<QuestGiver>();
                questContainer.currentStateIndex = npc.questIndex;
            }
        }

        foreach (PlayerItemData player in gameData.players)
        {
            GameObject realPlayer = GameObject.Find(player.name);
            if (realPlayer == null)
            {
                if (String.IsNullOrEmpty(player.itemBaseName) == false)
                {
                    realPlayer = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("PreFabs/" + player.itemBaseName));
                    realPlayer.name = player.name;
                }
                else
                {
                    Debug.LogWarning("Loading item '" + player.name + "' failed.");
                    continue;
                }
            }
            realPlayer.transform.position = new Vector3(player.position[0], player.position[1], realPlayer.transform.position.z);
            realPlayer.transform.rotation = new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], player.rotation[3]);

            TrailOffsetInventory playerInventory = realPlayer.GetComponent<TrailOffsetInventory>();
            foreach (String itemName in player.inventory.items)
            {
                GameObject invenItem = GameObject.Find(itemName);
                if(invenItem != null)
                {
                    playerInventory.AddItemAtBack(invenItem.GetComponent<Item>());
                }
                else
                {
                    Debug.LogWarning("Failed to find item '" + invenItem+"'");
                }
            }

        }
    }
}

[Serializable]
public class GameData {

    public String sceneBaseName;
    public List<ItemData> items = new List<ItemData>();
    public List<NPCItemData> npcs = new List<NPCItemData>();
    public List<PlayerItemData> players = new List<PlayerItemData>();

    public GameData()
    {
        this.sceneBaseName = SceneManager.GetActiveScene().name;
        foreach(Item item in FindAllItems())
        {
            //Debug.Log(item.name+": "+item.gameObject.activeSelf);
            if(item is NPC)
            {
                //Debug.Log("NPC - " +item.name);
                npcs.Add(new NPCItemData(item as NPC));
            }
            else if(item is Player)
            {
                //Debug.Log("Player - " + item.name);
                players.Add(new PlayerItemData(item as Player));
            }
            else
            {
                //Debug.Log("Item - " + item.name);
                items.Add(new ItemData(item));
            }
        }
    }

    private static List<Item> FindAllItems()
    {
        List<Item> results = new List<Item>();
        new List<GameObject>(SceneManager.GetActiveScene().GetRootGameObjects()).ForEach(g => results.AddRange(g.GetComponentsInChildren<Item>(true)));
        return results;
    }

}

[Serializable]
public class ItemData
{
    public String name;
    public String itemBaseName;
    public float[] position;
    public float[] rotation;
    public bool disabled;

    public ItemData(Item item)
    {
        name = item.name;
        if (String.IsNullOrEmpty(item.itemBaseName) == false)
        {
            itemBaseName = item.itemBaseName;
        }
        disabled = !item.gameObject.activeInHierarchy;
        position = new float[] { item.transform.position.x, item.transform.position.y };
        rotation = new float[] { item.transform.rotation.x, item.transform.rotation.y, item.transform.rotation.z, item.transform.rotation.w };
    }
}

[Serializable]
public class NPCItemData : ItemData
{
    public int questIndex;

    public NPCItemData(NPC npc) : base(npc)
    {
        QuestGiver questContainer = npc.GetComponent<QuestGiver>();
        if (questContainer != null)
        {
            questIndex = npc.GetComponent<QuestGiver>().currentStateIndex;
        }
        else
        {
            questIndex = -1;
        }
    }
}

[Serializable]
public class PlayerItemData : ItemData
{
    public InventoryData inventory;

    public PlayerItemData(Player player) : base(player)
    {
        inventory = new InventoryData(player.GetComponent<Inventory>());
    }
}

[Serializable]
public class InventoryData
{
    public List<String> items;

    public InventoryData(Inventory inventory)
    {
        items = inventory.GetAllItemNames();
    }
}
