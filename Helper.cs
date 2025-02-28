using UnityEngine;
using System.Collections.Generic;

public static class UIHelper
{
    private static float referenceWidth = 1920f;
    private static float referenceHeight = 1080f;

    private static GUIStyle highlightedToggle;
    private static GUIStyle defaultToggle;
    private static GUIStyle sectionStyle;

    private static Dictionary<int, UIElement> registeredWindows = new Dictionary<int, UIElement>();

    /// <summary>
    /// Registers a new UI window dynamically.
    /// </summary>
    public static void RegisterWindow(int id, ref Rect windowRect, GUI.WindowFunction windowFunction, string title, ref bool isVisible)
    {
        if (!registeredWindows.ContainsKey(id))
        {
            registeredWindows[id] = new UIElement
            {
                WindowRect = windowRect,
                WindowFunction = windowFunction,
                Title = title,
                IsVisible = isVisible
            };
        }
    }

    /// <summary>
    /// Draws only the Main Menu UI.
    /// </summary>
    public static void DrawMenu()
    {
        if (registeredWindows.ContainsKey(0))
        {
            // Ensure visibility is up-to-date
            registeredWindows[0].IsVisible = MainMenuUI.IsVisible;

            if (registeredWindows[0].IsVisible)
            {
                registeredWindows[0].WindowRect = CreateWindow(0, registeredWindows[0].WindowRect, registeredWindows[0].WindowFunction, registeredWindows[0].Title);
            }
        }
    }

    public static Rect CreateWindow(int id, Rect windowRect, GUI.WindowFunction windowFunction, string title)
    {
        float scaleX = Screen.width / referenceWidth;
        float scaleY = Screen.height / referenceHeight;
        Matrix4x4 originalMatrix = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(scaleX, scaleY, 1));

        windowRect.x = Mathf.Clamp(windowRect.x, 0, referenceWidth - windowRect.width);
        windowRect.y = Mathf.Clamp(windowRect.y, 0, referenceHeight - windowRect.height);
        windowRect = GUILayout.Window(id, windowRect, windowFunction, title);

        GUI.matrix = originalMatrix;
        return windowRect;
    }

    public static void InitializeStyles()
    {
        if (highlightedToggle == null)
        {
            highlightedToggle = new GUIStyle(GUI.skin.toggle) { fontStyle = FontStyle.Bold };
            highlightedToggle.normal.textColor = Color.white;
            highlightedToggle.hover.textColor = Color.green;
            highlightedToggle.onNormal.textColor = Color.green;
            highlightedToggle.onHover.textColor = Color.yellow;

            defaultToggle = new GUIStyle(GUI.skin.toggle);
            defaultToggle.normal.textColor = Color.white;

            sectionStyle = new GUIStyle(GUI.skin.box)
            {
                padding = new RectOffset(10, 10, 10, 10),
                margin = new RectOffset(10, 10, 10, 10)
            };
        }
    }

    public static GUIStyle GetSectionStyle() => sectionStyle;
    public static GUIStyle GetHighlightedToggle() => highlightedToggle;
    public static GUIStyle GetDefaultToggle() => defaultToggle;

    private class UIElement
    {
        public Rect WindowRect;
        public GUI.WindowFunction WindowFunction;
        public string Title;
        public bool IsVisible;
    }
}
public class MainMenuUI
{
    private static Rect mainMenuRect = new Rect(Screen.width - 250, 50, 250, 300);
    public static bool IsVisible = true;

    public static void RegisterWindows()
    {
        UIHelper.RegisterWindow(0, ref mainMenuRect, MainMenuWindow, "Main Menu", ref IsVisible);
    }

    public static void Draw() => UIHelper.DrawMenu();

    private static void MainMenuWindow(int windowID)
    {
        UIHelper.InitializeStyles();
        GUI.DragWindow(new Rect(0, 0, 10000, 20));

        GUILayout.BeginVertical(UIHelper.GetSectionStyle());

        GUILayout.Label("Main Menu Template");

        GUILayout.EndVertical();
    }
}

/*
public class SecondaryMenuUI
{
    private static Rect secondaryMenuRect = new Rect(Screen.width - 500, 100, 250, 200);
    public static bool IsVisible = false;

    public static void RegisterWindows()
    {
        UIHelper.RegisterWindow(1, ref secondaryMenuRect, SecondaryMenuWindow, "Secondary Menu", ref IsVisible);
    }

    private static void SecondaryMenuWindow(int windowID)
    {
        UIHelper.InitializeStyles();
        GUI.DragWindow(new Rect(0, 0, 10000, 20));

        GUILayout.BeginVertical(UIHelper.GetSectionStyle());

        GUILayout.Label("Secondary Menu Placeholder");

        GUILayout.EndVertical();
    }
}
*/
