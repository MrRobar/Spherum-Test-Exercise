using System.IO;
using UnityEngine;
using UnityEditor;

public class TextureImporterScript : MonoBehaviour
{
    [SerializeField] private string folderPath;

    [ContextMenu("SetSettings")]
    private void SetTextureImportSettingsInFolder()
    {
        string[] filePaths = Directory.GetFiles(folderPath);

        foreach (string filePath in filePaths)
        {
            if (filePath.EndsWith(".png") || filePath.EndsWith(".jpg"))
            {
                string assetPath = filePath.Replace(Application.dataPath, "Assets");

                TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;

                if (importer != null)
                {
                    importer.textureType = TextureImporterType.Default;
                    importer.wrapMode = TextureWrapMode.Repeat;
                    importer.filterMode = FilterMode.Trilinear;
                    importer.maxTextureSize = 1024;
                    importer.mipmapEnabled = true;
                    importer.alphaSource = TextureImporterAlphaSource.None;
                    importer.alphaIsTransparency = true;

                    importer.SaveAndReimport();
                }
            }
        }
    }
}