#if UNITY_EDITOR

using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;

namespace TMKOC.Grammer
{
    public class FolderCompressor : EditorWindow
    {
        private string inputFolderPath = "";
        private string outputFolderPath = "Assets/CompressedZips";
        private string zipFileName = "CompressedFolder.zip";


        [MenuItem("Tools/Compress Folder to ZIP")]
        public static void ShowWindow()
        {
            GetWindow<FolderCompressor>("Folder Compressor");
        }

        void OnGUI()
        {
            GUILayout.Label("Folder Compression Tool", EditorStyles.boldLabel);

            if (GUILayout.Button("Select Folder to Compress"))
            {
                inputFolderPath = EditorUtility.OpenFolderPanel("Select Folder", Application.dataPath, "");
            }

            GUILayout.Label("Selected Folder:", EditorStyles.label);
            GUILayout.TextField(inputFolderPath);

            GUILayout.Space(10);
            GUILayout.Label("Output Folder:", EditorStyles.label);
            outputFolderPath = GUILayout.TextField(outputFolderPath);

            GUILayout.Label("ZIP File Name:", EditorStyles.label);
            zipFileName = GUILayout.TextField(zipFileName);

            if (GUILayout.Button("Compress Folder"))
            {
                if (!string.IsNullOrEmpty(inputFolderPath) && !string.IsNullOrEmpty(outputFolderPath))
                {
                    CompressFolder(inputFolderPath, outputFolderPath, zipFileName);
                }
                else
                {
                    Debug.LogError("Please select an input folder and specify an output folder.");
                }
            }
        }

        void CompressFolder(string sourceFolder, string outputFolder, string zipName)
        {
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string zipPath = Path.Combine(outputFolder, zipName);

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath); // Overwrite existing ZIP
            }

            ZipFile.CreateFromDirectory(sourceFolder, zipPath);
            AssetDatabase.Refresh();

            Debug.Log($"Folder compressed successfully: {zipPath}");
        }
    }
}

#endif