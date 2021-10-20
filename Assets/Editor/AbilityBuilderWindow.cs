using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AbilityBuilderWindow : EditorWindow
{
   [MenuItem("Window/Ability Builder")]
   static void OpenWindow()
    {
        AbilityBuilderWindow _window = (AbilityBuilderWindow)GetWindow(typeof(AbilityBuilderWindow));
        _window.minSize = new Vector2(300, 400);
        _window.Show();
    }
}
