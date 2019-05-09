using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImageProcessor : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        if (assetPath.Contains(".png"))
        {
            Debug.Log("Loaded " + assetPath);
            TextureImporter myTextureImporter = (TextureImporter)assetImporter;
            myTextureImporter.spritePixelsPerUnit = 32;
            myTextureImporter.filterMode = FilterMode.Point;
            myTextureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
}
