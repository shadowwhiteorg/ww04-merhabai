using UnityEditor;
using UnityEngine;
using System.IO;

public class FolderSetup
{
    [MenuItem("Tools/Create Project Folders")]
    private static void CreateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/Art/Characters/Avatars",
            "Assets/Art/Environments/Backgrounds",
            "Assets/Art/Environments/Props",
            "Assets/Art/UI/Icons",
            "Assets/Art/UI/Menus",
            "Assets/Art/UI/Overlays",
            "Assets/Audio/Music",
            "Assets/Audio/SFX",
            "Assets/Materials",
            "Assets/Prefabs",
            "Assets/Resources",
            "Assets/Scenes",
            "Assets/Scripts/Core/Coroutines",
            "Assets/Scripts/Core/InputHandling",
            "Assets/Scripts/Core/PlatformSpecific/Android",
            "Assets/Scripts/Core/PlatformSpecific/WebGL",
            "Assets/Scripts/Core/Utilities",
            "Assets/Scripts/Features/AIChat",
            "Assets/Scripts/Features/VideoPlayer",
            "Assets/Scripts/Features/Suggestions",
            "Assets/Scripts/Managers",
            "Assets/Scripts/Player",
            "Assets/Scripts/Tools/ScriptableObjects",
            "Assets/Scripts/Tools/Serialization",
            "Assets/Scripts/Tools/Tweening",
            "Assets/Scripts/Tools/CustomInterfaces",
            "Assets/Scripts/UI/Controls",
            "Assets/Scripts/UI/HUD",
            "Assets/Shaders",
            "Assets/Textures"
        };

        foreach (string folder in folders)
        {
            if (!AssetDatabase.IsValidFolder(folder))
            {
                string parentFolder = Path.GetDirectoryName(folder);
                string newFolder = Path.GetFileName(folder);
                AssetDatabase.CreateFolder(parentFolder, newFolder);
            }

            string readmePath = Path.Combine(folder, "readit.md");
            if (!File.Exists(readmePath))
            {
                string folderName = Path.GetFileName(folder);
                string readmeContent = $"# {folderName}\n\nThis folder contains assets related to {folderName}.";

                // Create the directory if it doesn't exist
                Directory.CreateDirectory(Path.GetDirectoryName(readmePath));

                File.WriteAllText(readmePath, readmeContent);
            }
        }

        AssetDatabase.Refresh();
    }
}
