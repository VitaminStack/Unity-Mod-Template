using BepInEx;
using HarmonyLib;
using UnityEngine;

public static class ModInfo
{
    public const string PLUGIN_GUID = "com.example.DiplomacyMod";
    public const string PLUGIN_NAME = "DiplomacyMod";
    public const string PLUGIN_VERSION = "1.0.0";
}

[BepInPlugin(ModInfo.PLUGIN_GUID, ModInfo.PLUGIN_NAME, ModInfo.PLUGIN_VERSION)]
public class Main : BaseUnityPlugin
{
    private Harmony harmony;
    public static bool DebugLogging = true; // ✅ Toggle this to enable/disable logging
    public static string LogInfoColor = "cyan"; // 🎨 Change Info log color
    public static string LogWarningColor = "orange"; // 🎨 Change Warning log color
    public static string LogErrorColor = "red"; // 🎨 Change Error log color

    void Awake()
    {
        if (DebugLogging) ModLogger.LogInfo($"{ModInfo.PLUGIN_NAME} v{ModInfo.PLUGIN_VERSION} loaded!");
        Patcher.ApplyPatches();

        // ✅ Register Main Menu Window
        MainMenuUI.RegisterWindows();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            MainMenuUI.IsVisible = !MainMenuUI.IsVisible;
            if (DebugLogging) ModLogger.LogInfo($"Main Menu visibility toggled: {MainMenuUI.IsVisible}");
        }
    }

    void OnGUI()
    {
        UIHelper.DrawMenu();
    }
}
