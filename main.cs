using BepInEx;
using HarmonyLib;
using UnityEngine;

public static class ModInfo
{
    public const string PLUGIN_GUID = "com.example.unitymod";
    public const string PLUGIN_NAME = "Universal Unity Mod";
    public const string PLUGIN_VERSION = "1.0.0";
}

[BepInPlugin(ModInfo.PLUGIN_GUID, ModInfo.PLUGIN_NAME, ModInfo.PLUGIN_VERSION)]
public class Main : BaseUnityPlugin
{
    private Harmony harmony;

    void Awake()
    {
        ModLogger.LogInfo($"{ModInfo.PLUGIN_NAME} v{ModInfo.PLUGIN_VERSION} loaded!");
        Patcher.ApplyPatches();

        // ✅ Register Windows at Startup
        MainMenuUI.RegisterWindows();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            MainMenuUI.IsVisible = !MainMenuUI.IsVisible;
            ModLogger.LogInfo($"Main Menu visibility toggled: {MainMenuUI.IsVisible}");
        }
    }

    void OnGUI()
    {
        UIHelper.DrawMenu();
    }
}
