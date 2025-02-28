using BepInEx.Logging;

public static class ModLogger
{
    private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(ModInfo.PLUGIN_NAME);

    private static string Prefix => $"[{ModInfo.PLUGIN_NAME}] ";

    public static void LogInfo(string message)
    {
        logger.LogInfo(Prefix + message);
    }

    public static void LogWarning(string message)
    {
        logger.LogWarning(Prefix + message);
    }

    public static void LogError(string message)
    {
        logger.LogError(Prefix + message);
    }
}
