using UnityEditor;
using UnityEngine;

public class MenuBarOptions
{
    [MenuItem("CreateFromTexture/Item")]
    public static void CreateItemPrefab()
    {
        UnityEngine.Object[] selectedObjects = Selection.objects;
        if (selectedObjects.Length > 0)
        {
            foreach (UnityEngine.Object obj in selectedObjects)
            {
                if (obj is Texture2D)
                {
                    Texture2D texture = obj as Texture2D;
                    if (Resources.Load("Assets/Resources/PreFabs/Item/" + texture.name) == false)
                    {
                        GameObject newPrefab = PrefabUtility.CreatePrefab("Assets/Resources/PreFabs/Item/" + texture.name + ".prefab", new GameObject());
                        newPrefab.AddComponent<Item>();
                        newPrefab.layer = LayerMask.NameToLayer("Foreground");

                        Rigidbody2D rb = newPrefab.GetComponent<Rigidbody2D>();
                        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
                        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

                        BoxCollider2D coll = newPrefab.GetComponent<BoxCollider2D>();
                        coll.size = new Vector2(1, 1);

                        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/" + texture.name + ".png");
                        newPrefab.GetComponent<SpriteRenderer>().sprite = sprite;

                        Selection.activeObject = newPrefab;
                        Debug.Log("Item " + texture.name + " Created!");
                    }
                }
            }
        }
        else
        {
            GameObject newPrefab = PrefabUtility.CreatePrefab("Assets/Resources/PreFabs/Item/NewItem.prefab", new GameObject());
            newPrefab.AddComponent<Item>();
            newPrefab.layer = LayerMask.NameToLayer("Foreground");

            Rigidbody2D rb = newPrefab.GetComponent<Rigidbody2D>();
            rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            BoxCollider2D coll = newPrefab.GetComponent<BoxCollider2D>();
            coll.size = new Vector2(1, 1);

            Selection.activeObject = newPrefab;
            Debug.Log("NewItem Created!");
        }
    }

    [MenuItem("CreateFromTexture/NPC")]
    public static void CreateNPCPrefab()
    {
        UnityEngine.Object[] selectedObjects = Selection.objects;
        if (selectedObjects.Length > 0)
        {
            foreach (UnityEngine.Object obj in selectedObjects)
            {
                if (obj is Texture2D)
                {
                    Texture2D texture = obj as Texture2D;
                    if (Resources.Load("Assets/Resources/PreFabs/NPC/" + texture.name) == false)
                    {
                        GameObject newPrefab = PrefabUtility.CreatePrefab("Assets/Resources/PreFabs/NPC/" + texture.name + ".prefab", new GameObject());
                        newPrefab.AddComponent<NPC>();
                        newPrefab.layer = LayerMask.NameToLayer("NPC");

                        NPC npc = newPrefab.GetComponent<NPC>();
                        npc.isPickupable = false;

                        Rigidbody2D rb = newPrefab.GetComponent<Rigidbody2D>();
                        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
                        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

                        BoxCollider2D coll = newPrefab.GetComponent<BoxCollider2D>();
                        coll.size = new Vector2(1, 1);

                        DetectionRange detector = newPrefab.GetComponent<DetectionRange>();
                        detector.TargetMask = (1 << LayerMask.NameToLayer("Foreground")) | (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("NPC"));
                        detector.ObstacleMask = (1 << LayerMask.NameToLayer("BoundaryTiles"));

                        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/" + texture.name + ".png");
                        newPrefab.GetComponent<SpriteRenderer>().sprite = sprite;

                        Selection.activeObject = newPrefab;
                        Debug.Log("NPC " + texture.name + " Created!");
                    }
                }
            }
        }
        else
        {
            GameObject newPrefab = PrefabUtility.CreatePrefab("Assets/Resources/PreFabs/NPC/NewNPC.prefab", new GameObject());
            newPrefab.AddComponent<NPC>();
            newPrefab.layer = LayerMask.NameToLayer("NPC");

            NPC npc = newPrefab.GetComponent<NPC>();
            npc.isPickupable = false;

            Rigidbody2D rb = newPrefab.GetComponent<Rigidbody2D>();
            rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            BoxCollider2D coll = newPrefab.GetComponent<BoxCollider2D>();
            coll.size = new Vector2(1, 1);

            Selection.activeObject = newPrefab;
            Debug.Log("NewNPC Created!");
        }
    }

    [MenuItem("HelperFunctions/Add Questing")]
    public static void SetUpQuesting()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject obj = Selection.activeGameObject;
            if (obj.GetComponent<Item>() != null && obj.GetComponent<QuestGiver>() == null)
            {
                obj.AddComponent<QuestGiver>();
                GameObject dialogPopup = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("PreFabs/Quest/DialogPopup"), obj.transform);
                dialogPopup.name = "DialogPopup";
                GameObject statelist = new GameObject("QuestStates");
                statelist.transform.SetParent(obj.transform);
                GameObject starter = new GameObject("Quest_Name_Here");
                starter.AddComponent<QuestStateQuest>().text = "NPC_Text_Here";
                starter.transform.SetParent(statelist.transform);
            }
        }
    }
}
