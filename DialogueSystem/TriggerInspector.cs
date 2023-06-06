using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(DialogeTrigger))]
public class TriggerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DialogeTrigger trigger = (DialogeTrigger)target;
        if (GUILayout.Button("TriggerDialogue"))
        {
            trigger.TriggerDialogue();
        }
    }
}
