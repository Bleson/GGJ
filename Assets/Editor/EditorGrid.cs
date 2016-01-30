using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Spell))]
public class EditorGrid : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //base.OnInspectorGUI();
    }
}
