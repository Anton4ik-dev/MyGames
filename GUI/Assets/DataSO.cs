using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DataSO : ScriptableObject
{
    [SerializeField] private long id;
    [SerializeField] private ClipType clipType;
    [SerializeField] private List<AudioInfo> audiosDanger = new List<AudioInfo>();
    [SerializeField] private List<AudioInfo> audiosFriendly = new List<AudioInfo>();
    [SerializeField] private List<AudioInfo> audiosNeutral = new List<AudioInfo>();
    [SerializeField] private string text;

    public enum ClipType
    {
        Danger = 0,
        Friendly = 1,
        Neutral = 2
    }

    [CustomEditor(typeof(DataSO))]
    public class DataSimpleCustomEditor : Editor
    {
        SerializedProperty m_id;
        SerializedProperty m_enum;
        SerializedProperty m_list;
        string m_text;

        bool isList;
        bool isText;
        public override void OnInspectorGUI()
        {
            m_id = serializedObject.FindProperty("id");
            EditorGUILayout.PropertyField(m_id, new GUIContent("ID"));

            DrawButtons();

            if (isList)
                DrawList();
            if (isText)
                DrawText();

            serializedObject.ApplyModifiedProperties();
        }

        public void DrawList()
        {
            m_enum = serializedObject.FindProperty("clipType");
            EditorGUILayout.PropertyField(m_enum, new GUIContent("Enum"));
            if (m_enum.intValue == 0)
            {
                m_list = serializedObject.FindProperty("audiosDanger");
                EditorGUILayout.PropertyField(m_list, new GUIContent("AudiosDanger"));
            } else if(m_enum.intValue == 1)
            {
                m_list = serializedObject.FindProperty("audiosFriendly");
                EditorGUILayout.PropertyField(m_list, new GUIContent("AudiosFriendly"));
            } else if (m_enum.intValue == 2)
            {
                m_list = serializedObject.FindProperty("audiosNeutral");
                EditorGUILayout.PropertyField(m_list, new GUIContent("AudiosNeutral"));
            }
        }
        public void DrawText()
        {
            m_text = serializedObject.FindProperty("text").stringValue;
            EditorGUILayout.TextArea(m_text, GUILayout.Height(80));
        }

        public void DrawButtons()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("List"))
            {
                isList = !isList;
            }
            if (GUILayout.Button("Text"))
            {
                isText = !isText;
            }
            if (GUILayout.Button("Show"))
            {
                isList = false;
                isText = false;
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}