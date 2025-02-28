using HarmonyLib;
using System;
using System.Reflection;

public static class Patcher
{
    private static Harmony harmony;

    public static void ApplyPatches()
    {
        harmony = new Harmony(ModInfo.PLUGIN_GUID);

        try
        {
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            ModLogger.LogInfo("Harmony patches successfully applied.");
        }
        catch (Exception ex)
        {
            ModLogger.LogError("Error while applying patches: " + ex.Message);
        }
    }

    /* --- Example Patch for a Method ---
     * 
     * If you want to patch a specific method, you can define the patch as follows:
     * 
     * [HarmonyPatch(typeof(TargetClass), "TargetMethod")]
     * public static class ExamplePatch
     * {
     *     static void Prefix() // Prefix runs before the method executes
     *     {
     *         ModLogger.LogInfo("Patch executed BEFORE the method.");
     *     }
     *     static void Postfix() // Postfix runs after the method executes
     *     {
     *         ModLogger.LogInfo("Patch executed AFTER the method.");
     *     }
     * }
     * 
     */

    /* --- Possible Additional Patches ---
     *
     * - Prefix: Runs BEFORE the original method, allowing you to modify parameters or cancel execution.
     * - Postfix: Runs AFTER the original method, useful for modifying return values or logging.
     * - Transpiler: Allows modifying the IL (Intermediate Language) of the method, for complex changes.
     * - Finalizer: Runs after a method, even if an exception occurs, useful for cleanup logic.
     *
     */

    /* --- Example: Modifying Method Parameters (Prefix) ---
     * This example modifies a parameter before the original method runs.
     *
     * [HarmonyPatch(typeof(TargetClass), "TargetMethod")]
     * public static class ModifyParameterPatch
     * {
     *     static void Prefix(ref int someParameter)
     *     {
     *         ModLogger.LogInfo($"Original parameter: {someParameter}");
     *         someParameter *= 2; // Double the parameter value
     *         ModLogger.LogInfo($"Modified parameter: {someParameter}");
     *     }
     * }
     *
     */

    /* --- Example: Changing the Return Value (Postfix) ---
     * This example modifies the return value of a method.
     *
     * [HarmonyPatch(typeof(TargetClass), "TargetMethod")]
     * public static class ModifyReturnValuePatch
     * {
     *     static void Postfix(ref int __result)
     *     {
     *         ModLogger.LogInfo($"Original return value: {__result}");
     *         __result += 10; // Add 10 to the return value
     *         ModLogger.LogInfo($"Modified return value: {__result}");
     *     }
     * }
     *
     */

    /* --- Example: Cancelling Method Execution (Prefix) ---
     * This example prevents the original method from running.
     *
     * [HarmonyPatch(typeof(TargetClass), "TargetMethod")]
     * public static class CancelMethodPatch
     * {
     *     static bool Prefix()
     *     {
     *         ModLogger.LogWarning("Method execution was cancelled!");
     *         return false; // Returning false prevents the method from executing
     *     }
     * }
     *
     */

    /* --- Example: Transpiler (Advanced Method Modification) ---
     * This example modifies the IL code of the method.
     *
     * [HarmonyPatch(typeof(TargetClass), "TargetMethod")]
     * public static class ILPatch
     * {
     *     static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
     *     {
     *         foreach (var instruction in instructions)
     *         {
     *             if (instruction.opcode == OpCodes.Ldc_I4_5) // Find where '5' is loaded
     *             {
     *                 instruction.operand = 10; // Change it to '10'
     *             }
     *             yield return instruction;
     *         }
     *     }
     * }
     *
     */

    /* --- Example: Running Code Even if an Exception Occurs (Finalizer) ---
     * Finalizers always run, even if an error happens.
     *
     * [HarmonyPatch(typeof(TargetClass), "TargetMethod")]
     * public static class FinalizerPatch
     * {
     *     static void Finalizer()
     *     {
     *         ModLogger.LogInfo("Finalizer executed, method completed (even if an exception occurred).");
     *     }
     * }
     *
     */

}

