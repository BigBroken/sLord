using UnityEngine;
using System.Collections;

namespace PixelCrushers.DialogueSystem
{

    [AddComponentMenu("Dialogue System/UI/Miscellaneous/Replace Display Settings")]
    public class ReplaceDisplaySettings : MonoBehaviour
    {

        public bool replaceDialogueUI = false;

        public GameObject dialogueUI = null;

        public bool replaceSubtitleSettings = false;

        public DisplaySettings.SubtitleSettings subtitleSettings = new DisplaySettings.SubtitleSettings();

        public bool replaceCameraSettings = false;

        public DisplaySettings.CameraSettings cameraSettings = new DisplaySettings.CameraSettings();

        public bool replaceInputSettings = false;

        public DisplaySettings.InputSettings inputSettings = new DisplaySettings.InputSettings();

        public bool revertOnDestroy = true;

        private GameObject originalDialogueUI = null;
        private DisplaySettings.SubtitleSettings originalSubtitleSettings = null;
        private DisplaySettings.CameraSettings originalCameraSettings = null;
        private DisplaySettings.InputSettings originalInputSettings = null;
        private bool quitting = false;

        void Start()
        {
            originalDialogueUI = DialogueManager.DisplaySettings.dialogueUI;
            originalSubtitleSettings = DialogueManager.DisplaySettings.subtitleSettings;
            originalCameraSettings = DialogueManager.DisplaySettings.cameraSettings;
            originalInputSettings = DialogueManager.DisplaySettings.inputSettings;
            if (replaceDialogueUI) DialogueManager.UseDialogueUI(dialogueUI);
            if (replaceSubtitleSettings) DialogueManager.DisplaySettings.subtitleSettings = subtitleSettings;
            if (replaceCameraSettings) DialogueManager.DisplaySettings.cameraSettings = cameraSettings;
            if (replaceInputSettings) DialogueManager.DisplaySettings.inputSettings = inputSettings;
        }

        void OnDestroy()
        {
            if (quitting) return;
            if (replaceDialogueUI && originalDialogueUI != null) DialogueManager.UseDialogueUI(originalDialogueUI);
            if (replaceSubtitleSettings) DialogueManager.DisplaySettings.subtitleSettings = originalSubtitleSettings;
            if (replaceCameraSettings) DialogueManager.DisplaySettings.cameraSettings = originalCameraSettings;
            if (replaceInputSettings) DialogueManager.DisplaySettings.inputSettings = originalInputSettings;
        }

        void OnApplicationQuit()
        {
            quitting = true;
        }
    }
}