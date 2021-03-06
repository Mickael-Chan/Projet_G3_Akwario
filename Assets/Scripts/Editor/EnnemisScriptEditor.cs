﻿using UnityEditor;
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
           // myScript.oursinShape = (Transform)EditorGUILayout.ObjectField("Oursin Shape", myScript.oursinShape, typeof(Transform), true);

        }
        if (myScript.ennemisSelected == EnnemisScript.ennemisList.poissonLanterne)
        {
            myScript.ennemisPushSpeed = EditorGUILayout.FloatField("Ennemis Push Speed", myScript.ennemisPushSpeed);
        }
    }
}
