using BepInEx.Logging;
using UnityEngine; // Needed for rich text colors

public static class ModLogger
{
    private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(ModInfo.PLUGIN_NAME);
    private static string Prefix => $"[{ModInfo.PLUGIN_NAME}] ";

    public static void LogInfo(string message)
    {
        string coloredMessage = $"<color={Main.LogInfoColor}>{Prefix}{message}</color>";
        logger.LogInfo(coloredMessage);
    }

    public static void LogWarning(string message)
    {
        string coloredMessage = $"<color={Main.LogWarningColor}>{Prefix}{message}</color>";
        logger.LogWarning(coloredMessage);
    }

    public static void LogError(string message)
    {
        string coloredMessage = $"<color={Main.LogErrorColor}>{Prefix}{message}</color>";
        logger.LogError(coloredMessage);
    }
}
