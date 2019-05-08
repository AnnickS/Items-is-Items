using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DescriptorPostProcessor : AssetPostprocessor {

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        AssetDatabase.Refresh();
        List<string> pathsVisited = new List<string>();

        for (int i = 0; i < movedAssets.Length; i++)
        {
            //Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
            if (movedAssets[i].Contains("/Descriptors/") && movedFromAssetPaths[i].Contains("/Descriptors/"))
            {
                int startIndex = movedAssets[i].LastIndexOf('/') + 1;
                string filename = movedAssets[i].Substring(startIndex, movedAssets[i].Length - startIndex - 6);
                int startIndexOld = movedFromAssetPaths[i].LastIndexOf('/') + 1;
                string filenameOld = movedFromAssetPaths[i].Substring(startIndexOld, movedFromAssetPaths[i].Length - startIndexOld - 6);
                AssetDatabase.RenameAsset("Assets/Resources/Validators/" + filenameOld + ".asset", filename);

                pathsVisited.Add(movedAssets[i]);
                Debug.Log("DescriptorValidator " + filenameOld + " renamed to " + filename);
            }
        }
        AssetDatabase.SaveAssets();

        AssetDatabase.Refresh();
        foreach(string str in deletedAssets)
        {
            if (str.Contains("/Descriptors/"))
            {
                int startIndex = str.LastIndexOf('/') + 1;
                string filename = str.Substring(startIndex, str.Length - startIndex - 6);
                DescriptorValidator val = AssetDatabase.LoadAssetAtPath<DescriptorValidator>("Assets/Resources/Validators/" + filename + ".asset");
                if (val != null)
                {
                    AssetDatabase.DeleteAsset("Assets/Resources/Validators/" + filename + ".asset");
                    Debug.Log("Delted DescriptorValidator " + filename);
                }
            }
        }
        AssetDatabase.SaveAssets();

        AssetDatabase.Refresh();
        foreach (string str in importedAssets)
        {
            if (pathsVisited.Contains(str))
            {
                continue;
            }
            if (str.Contains("/Descriptors/")) {
                int startIndex = str.LastIndexOf('/') + 1;
                string filename = str.Substring(startIndex, str.Length - startIndex - 6);
                DescriptorValidator val = AssetDatabase.LoadAssetAtPath<DescriptorValidator>("Assets/Resources/Validators/" + filename + ".asset");
                if(val == null)
                {
                    DescriptorValidator newVal = DescriptorValidator.CreateInstance<DescriptorValidator>();
                    Descriptor des = AssetDatabase.LoadAssetAtPath<Descriptor>("Assets/Resources/Descriptors/" + filename + ".asset");
                    newVal.descriptor = des;
                    AssetDatabase.CreateAsset(newVal, "Assets/Resources/Validators/" + filename + ".asset");
                    Debug.Log("DescriptorValidator " + filename + " created");
                }
            }
        }
        AssetDatabase.SaveAssets();
    }
}
