using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyDatabase))]
public class DatabaseEditor : Editor
{
    private EnemyDatabase database;

    private void Awake()
    {
        database = (EnemyDatabase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Remove All!"))
        {
            database.ClearDatabase();
        }

        if (GUILayout.Button("Remove"))
        {
            database.RemoveCurrentIndex();
        }

        if (GUILayout.Button("Add"))
        {
            database.AddElement();
        }

        if (GUILayout.Button("<="))
        {
            database.GetPrev();
        }

        if (GUILayout.Button("=>"))
        {
            database.GetNext();
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
