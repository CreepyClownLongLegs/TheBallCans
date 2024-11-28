using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.SceneManagement{


    public class SceneLoader : PersistentSingleton<SceneLoader>{
        [SerializeField] Image loadingBar;
        [SerializeField] float fillSpeed = 0.5f;
        [SerializeField] Canvas loadingCanvas;
        [SerializeField] Camera loadingCamera;
        [SerializeField] SceneGroup[] sceneGroups;

        float targetProgress;
        public bool isLoading;

        public List<string> loadedScenes;
        public static event Action newSceneGrouploaded;

        public readonly SceneGroupManager manager = new SceneGroupManager();
        CharacterController2D characterController;
        
        void Awake() {
            // TODO can remove
            manager.OnSceneLoaded += sceneName => Debug.Log("Loaded: " + sceneName);
            manager.OnSceneLoaded += SaveSceneNames;
            manager.OnSceneUnloaded += sceneName => Debug.Log("Unloaded: " + sceneName);
            manager.OnSceneUnloaded += DeleteSceneName;
            manager.OnSceneGroupLoaded += () => Debug.Log("Scene group loaded");
        }


        async void Start() {
            await LoadSceneGroup(0);
        }

        void SaveSceneNames(string sceneName){
            loadedScenes.Add(sceneName);
        }

        void DeleteSceneName(string sceneName){
            loadedScenes.Remove(sceneName);
        }
        
        void Update() {
            if (!isLoading) return;
            
            float currentFillAmount = loadingBar.fillAmount;
            float progressDifference = Mathf.Abs(currentFillAmount - targetProgress);

            float dynamicFillSpeed = progressDifference * fillSpeed;
    
            loadingBar.fillAmount = Mathf.Lerp(currentFillAmount, targetProgress, Time.deltaTime * dynamicFillSpeed);
        }

        public async Task LoadSceneGroup(int index) {
            loadingBar.fillAmount = 0f;
            targetProgress = 1f;

            if (index < 0 || index >= sceneGroups.Length) {
                Debug.LogError("Invalid scene group index: " + index);
                return;
            }

            LoadingProgress progress = new LoadingProgress();
            progress.Progressed += target => targetProgress = Mathf.Max(target, targetProgress);
            
            EnableLoadingCanvas();
            await manager.LoadScenes(sceneGroups[index], progress);
            EnableLoadingCanvas(false);
            newSceneGrouploaded?.Invoke();
        }
    
        void EnableLoadingCanvas(bool enable = true) {
            isLoading = enable;
            loadingCanvas.gameObject.SetActive(enable);
            loadingCamera.gameObject.SetActive(enable);
        }
        
    }


public class LoadingProgress : IProgress<float>
{
    public event Action<float> Progressed;
    const float ratio = 1f;
        public void Report(float value)
        {
            Progressed?.Invoke(value/ratio);
        }

}
}