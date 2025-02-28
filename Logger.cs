using BepInEx.Logging;

public static class ModLogger
{
    private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(ModInfo.PLUGIN_NAME);
    private static string Prefix => $"[{ModInfo.PLUGIN_NAME}] ";

    public static void LogInfo(string message)
    {
        logger.LogInfo(Prefix + message); // ✅ Uses BepInEx's default coloring for Info
    }

    public static void LogWarning(string message)
    {
        logger.LogWarning(Prefix + message); // ✅ Yellow color for warnings
    }

    public static void LogError(string message)
    {
        logger.LogError(Prefix + message); // ✅ Red color for errors
    }

    public static void LogDebug(string message)
    {
        logger.LogDebug(Prefix + message); // ✅ Debug mode (blue if enabled)
    }
}
