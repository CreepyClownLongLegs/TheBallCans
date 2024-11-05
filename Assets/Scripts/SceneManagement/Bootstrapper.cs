
using UnityEngine.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class Bootstrapper:PersistentSingleton<Bootstrapper>{
    // NOTE: This script is intended to be placed in your first scene included in the build settings.
    static readonly int sceneIndex = 0;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init() {
        Debug.Log("Bootstrapper...");
#if UNITY_EDITOR
        // Set the bootstrapper scene to be the play mode start scene when running in the editor
        // This will cause the bootstrapper scene to be loaded first (and only once) when entering
        // play mode from the Unity Editor, regardless of which scene is currently active.
        EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorBuildSettings.scenes[sceneIndex].path);
#endif
}

}

    public class PersistentSingleton<T> : MonoBehaviour where T : Component {
        [Tooltip("if this is true, this singleton will auto detach if it finds itself parented on awake")]
        public bool UnparentOnAwake = true;

        public static bool HasInstance => instance != null;
        public static T Current => instance;

        protected static T instance;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindFirstObjectByType<T>();
                    if (instance == null) {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name + "AutoCreated";
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake() => InitializeSingleton();

        protected virtual void InitializeSingleton() {
            if (!Application.isPlaying) {
                return;
            }

            if (UnparentOnAwake) {
                transform.SetParent(null);
            }

            if (instance == null) {
                instance = this as T;
                DontDestroyOnLoad(transform.gameObject);
                enabled = true;
            } else {
                if (this != instance) {
                    Destroy(this.gameObject);
                }
            }
        }
    }