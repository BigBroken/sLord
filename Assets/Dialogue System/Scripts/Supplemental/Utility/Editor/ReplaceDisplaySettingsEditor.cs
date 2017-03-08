using UnityEngine;
using UnityEditor;

namespace PixelCrushers.DialogueSystem
{

    /// <summary>
    /// Custom inspector editor for ReplaceDisplaySettings.
    /// </summary>
    [CustomEditor(typeof(ReplaceDisplaySettings))]
    public class ReplaceDisplaySettingsEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            var script = target as ReplaceDisplaySettings;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("replaceDialogueUI"));
            serializedObject.ApplyModifiedProperties();
            if (script.replaceDialogueUI) EditorGUILayout.PropertyField(serializedObject.FindProperty("dialogueUI"), true);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("replaceSubtitleSettings"));
            serializedObject.ApplyModifiedProperties();
            if (script.replaceSubtitleSettings) EditorGUILayout.PropertyField(serializedObject.FindProperty("subtitleSettings"), true);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("replaceCameraSettings"));
            serializedObject.ApplyModifiedProperties();
            if (script.replaceCameraSettings) EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraSettings"), true);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("replaceInputSettings"));
            serializedObject.ApplyModifiedProperties();
            if (script.replaceInputSettings) EditorGUILayout.PropertyField(serializedObject.FindProperty("inputSettings"), true);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("revertOnDestroy"));
        }

    }

}
