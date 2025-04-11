using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace TMKOC.Reusable
{
    [InitializeOnLoad]
    internal class EasyShortCutLockInspector : MonoBehaviour
    {
        [MenuItem("Edit/Toggle Inspector Lock %l")]
        public static void Lock()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }

        [MenuItem("Edit/Toggle Inspector Lock %l", true)]
        public static bool Valid()
        {
            return ActiveEditorTracker.sharedTracker.activeEditors.Length != 0;
        }
    }
}
#endif
// This code adds a shortcut to lock the inspector in Unity.