using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class AbilityBuilderWindow : EditorWindow
{
    Texture2D _headerSectionTexture;
    Texture2D _physicalSectionTexture;
    Texture2D _magicalSectionTexture;
    Texture2D _listSectionTextrue;

    Color _headerSectionColor = new Color(22f/255f, 165f / 255f, 177f / 255f, 1);
    Color _physicalSectionColor = new Color(254f / 255f, 155f / 255f, 114f / 255f, 1);
    Color _magicalSectionColor = new Color(99f / 255f, 101f / 255f, 252f / 255f, 1);
    Color _listSectionColor = new Color(148f / 255f, 148f / 255f, 148f / 255f, 1);

    Rect _headerSection;
    Rect _physicalSection;
    Rect _magicalSection;
    Rect _listSection;

    static MagicalData _magicalData;
    static PhysicalData _physicalData;

    static CreateList.ListType _listType;

    public static MagicalData MagicInfo { get { return _magicalData; } }
    public static PhysicalData PhysicInfo { get { return _physicalData; } }
    


   [MenuItem("Window/Ability Builder")]
   static void OpenWindow()
    {
        AbilityBuilderWindow _window = (AbilityBuilderWindow)GetWindow(typeof(AbilityBuilderWindow));
        _window.minSize = new Vector2(600, 450);
        _window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public static void InitData()
    {
        _magicalData = (MagicalData)ScriptableObject.CreateInstance(typeof(MagicalData));
        _physicalData = (PhysicalData)ScriptableObject.CreateInstance(typeof(PhysicalData));
    }


    void InitTextures()
    {
        _headerSectionTexture = new Texture2D(1, 1);
        _headerSectionTexture.SetPixel(0, 0, _headerSectionColor);
        _headerSectionTexture.Apply();

        _physicalSectionTexture = new Texture2D(1, 1);
        _physicalSectionTexture.SetPixel(0, 0, _physicalSectionColor);
        _physicalSectionTexture.Apply();

        _magicalSectionTexture = new Texture2D(1, 1);
        _magicalSectionTexture.SetPixel(0, 0, _magicalSectionColor);
        _magicalSectionTexture.Apply();

        _listSectionTextrue = new Texture2D(1, 1);
        _listSectionTextrue.SetPixel(0, 0, _listSectionColor);
        _listSectionTextrue.Apply();


    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMagicalSettings();
        DrawPhysicalSettings();
        DrawListSettings();
    }

    void DrawLayouts()
    {
        _headerSection.x = 0;
        _headerSection.y = 0;
        _headerSection.width = Screen.width;
        _headerSection.height = 50;

        _physicalSection.x = 0;
        _physicalSection.y = 50;
        _physicalSection.width = Screen.width/2f;
        _physicalSection.height = Screen.height - 50;

        _magicalSection.x = Screen.width / 2f;
        _magicalSection.y = 50;
        _magicalSection.width = Screen.width / 2f;
        _magicalSection.height = Screen.height - 50;

        _listSection.x = 0;
        _listSection.y = Screen.height - 100;
        _listSection.width = Screen.width;
        _listSection.height = 100;

        GUI.DrawTexture(_headerSection, _headerSectionTexture);

        GUI.DrawTexture(_physicalSection, _physicalSectionTexture);

        GUI.DrawTexture(_magicalSection, _magicalSectionTexture);

        GUI.DrawTexture(_listSection, _listSectionTextrue);

    }

    void DrawHeader()
    {
        GUILayout.BeginArea(_headerSection);

        GUILayout.Label("Ability Builder");

        GUILayout.EndArea();


    }

    void DrawMagicalSettings() 
    {
        GUILayout.BeginArea(_magicalSection);

        GUILayout.Label("Magical Ability");

        GUILayout.Label("Ability Name");
        _magicalData._name = EditorGUILayout.TextField(_magicalData._name);

        GUILayout.Label("Magic Type");
        _magicalData._magicalType = (MagicalType)EditorGUILayout.EnumPopup(_magicalData._magicalType);

        GUILayout.Label("Attribute Type");
        _magicalData._magicalAttributeType = (MagicalAttributeType)EditorGUILayout.EnumPopup(_magicalData._magicalAttributeType);

        GUILayout.Label("Elemental Type");
        _magicalData._elementalType = (ElementalType)EditorGUILayout.EnumPopup(_magicalData._elementalType);

        GUILayout.Label("Power");
        _magicalData._power = EditorGUILayout.FloatField(_magicalData._power);

        GUILayout.Label("Cost");
        _magicalData._cost = EditorGUILayout.IntField(_magicalData._cost);

        if (GUILayout.Button("Create Ability", GUILayout.Height(50)))
        {
            CreateAbilityData("Magical");

        }

        GUILayout.EndArea();

    }
    

    void DrawPhysicalSettings()
    {
        GUILayout.BeginArea(_physicalSection);

        GUILayout.Label("Physical Ability");

        GUILayout.Label("Ability Name");
        _physicalData._name = EditorGUILayout.TextField(_physicalData._name);

        GUILayout.Label("Physic Type");
        _physicalData._physicalType = (PhysicalType)EditorGUILayout.EnumPopup(_physicalData._physicalType);

        GUILayout.Label("Attribute Type");
        _physicalData._physicalAttributeType = (PhysicalAttributeType)EditorGUILayout.EnumPopup(_physicalData._physicalAttributeType);

        GUILayout.Label("Elemental Type");
        _physicalData._elementalType = (ElementalType)EditorGUILayout.EnumPopup(_physicalData._elementalType);

        GUILayout.Label("Power");
        _physicalData._power = EditorGUILayout.FloatField(_physicalData._power);

        GUILayout.Label("Cost");
        _physicalData._cost = EditorGUILayout.IntField(_physicalData._cost);

        if (GUILayout.Button("Create Ability", GUILayout.Height(50)))
        {
            CreateAbilityData("Physical");

        }

        GUILayout.EndArea();

    }

    void DrawListSettings()
    {
        GUILayout.BeginArea(_listSection);

        GUILayout.Label("Create Ability List");
        _listType = (CreateList.ListType)EditorGUILayout.EnumPopup(_listType);
        if(GUILayout.Button("Create List", GUILayout.Height(40)))
        {
            CreateList.OpenWindow(_listType);
        }

        GUILayout.EndArea();

    }

    void CreateAbilityData(string type) 
    {
        if(type == "Magical")
        {
            string dataPath = "Assets/Resources/AbilityData/Data/";

            dataPath += "Magical/" + MagicInfo._name + ".asset";
            AssetDatabase.CreateAsset(MagicInfo, dataPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            InitData();
        }
        else if (type == "Physical")
        {
            string dataPath = "Assets/Resources/AbilityData/Data/";

            dataPath += "Physical/" + PhysicInfo._name + ".asset";
            AssetDatabase.CreateAsset(PhysicInfo, dataPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            InitData();
        }
    }

    
}
public class CreateList : EditorWindow
{
    Texture2D _headerSectionTexture;
    Texture2D _listSectionTexture;

    Color _headerSectionColor = new Color(22f / 255f, 165f / 255f, 177f / 255f, 1);
    Color _listSectionColor = new Color(0f / 255f, 160f / 255f, 80f / 255f, 1);

    Rect _headerSection;
    Rect _listSection;

    public enum ListType
    {
        Magical,
        Physical
    }

    static ListType _listType;
    static CreateList _window;

    static MagicList _magicList;
    static PhysicList _physicList;

    public static MagicList MagicListInfo { get { return _magicList; } }
    public static PhysicList PhysicListInfo { get { return _physicList; } }


    public static void OpenWindow(ListType type)
    {
        _listType = type;
        _window = (CreateList)GetWindow(typeof(CreateList));
        _window.minSize = new Vector2(250, 150);
        _window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
    }


    public static void InitData()
    {
        _magicList = (MagicList)ScriptableObject.CreateInstance(typeof(MagicList));
        _physicList = (PhysicList)ScriptableObject.CreateInstance(typeof(PhysicList));
    }

    void InitTextures()
    {
        _headerSectionTexture = new Texture2D(1, 1);
        _headerSectionTexture.SetPixel(0, 0, _headerSectionColor);
        _headerSectionTexture.Apply();

        _listSectionTexture = new Texture2D(1, 1);
        _listSectionTexture.SetPixel(0, 0, _listSectionColor);
        _listSectionTexture.Apply();


    }


    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawListSettings();
        
    }

    void DrawLayouts()
    {
        _headerSection.x = 0;
        _headerSection.y = 0;
        _headerSection.width = Screen.width;
        _headerSection.height = 50;

        _listSection.x = 0;
        _listSection.y = 50;
        _listSection.width = Screen.width;
        _listSection.height = Screen.height;

        GUI.DrawTexture(_headerSection, _headerSectionTexture);
        GUI.DrawTexture(_listSection, _listSectionTexture);


    }


    void DrawHeader()
    {
        GUILayout.BeginArea(_headerSection);

        if (_listType == ListType.Magical)
        {
            GUILayout.Label("Create Magical Ability List");
        }
        else if (_listType == ListType.Physical)
        {
            GUILayout.Label("Create Physical Ability List");
        }

        

        GUILayout.EndArea();


    }

    void DrawListSettings()
    {
        GUILayout.BeginArea(_listSection);

        GUILayout.Label("List Name");
        if(_listType == ListType.Magical)
        {
            _magicList._name = EditorGUILayout.TextField(_magicList._name);
            if (GUILayout.Button("Create Magical Ability List", GUILayout.Height(50)))
            {
                CreateAbilityList("Magical");

            }

        }
        else if(_listType == ListType.Physical)
        {
            _physicList._name = EditorGUILayout.TextField(_physicList._name);
            if (GUILayout.Button("Create Physical Ability List", GUILayout.Height(50)))
            {
                CreateAbilityList("Physical");

            }
        }
        


        GUILayout.EndArea();
    }
    void CreateAbilityList(string type)
    {
        if (type == "Magical")
        {
            string dataPath = "Assets/Resources/AbilityData/Data/";

            dataPath += "MagicalLists/" + MagicListInfo._name + ".asset";
            AssetDatabase.CreateAsset(MagicListInfo, dataPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            InitData();
        }
        else if (type == "Physical")
        {
            string dataPath = "Assets/Resources/AbilityData/Data/";

            dataPath += "PhysicalLists/" + PhysicListInfo._name + ".asset";
            AssetDatabase.CreateAsset(PhysicListInfo, dataPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            InitData();
        }
    }
}
