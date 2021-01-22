using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[CustomEditor(typeof(EnnemisScript))]
public class EnnemisScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EnnemisScript myScript = (EnnemisScript)target;
        base.OnInspectorGUI();
        
        if (myScript.ennemisSelected == EnnemisScript.ennemisList.oursin)
        {
            myScript.oursinShape = (GameObject)EditorGUILayout.ObjectField("Oursin Shape", myScript.oursinShape, typeof(object), true);
        }
    }
}
