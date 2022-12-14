using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Bayat.SaveSystem
{

    [AddComponentMenu("Bayat/Save System/Auto Save Manager")]
    public class AutoSaveManager : MonoBehaviour
    {

        private static AutoSaveManager current;

        /// <summary>
        /// Gets the current scene reference resolver.
        /// </summary>
        public static AutoSaveManager Current
        {
            get
            {
                if (current == null)
                {
                    AutoSaveManager[] instances = FindObjectsOfType<AutoSaveManager>();
#if !UNITY_EDITOR
                    if (instances.Length == 0)
                    {
                        CreateNewInstance();
                    }
#endif
                    if (instances.Length == 1)
                    {
                        current = instances[0];
                    }
                    else if (instances.Length > 1)
                    {
                        throw new InvalidOperationException("There is more than one AutoSaveManager in this scene, but there must only be one.");
                    }
                }
                return current;
            }
        }

        public enum SaveEvent
        {
            Manual,
            OnDisable,
            OnDestroy,
            OnApplicationQuit,
            OnApplicationPause,
            OnSceneUnloaded
        }

        public enum LoadEvent
        {
            Manual,
            OnEnable,
            Awake,
            Start,
            OnSceneLoaded
        }

        [SerializeField]
        protected string identifier = "autosave.dat";
        [SerializeField]
        protected SaveSystemSettingsPreset settingsPreset;
        [SerializeField]
        protected List<AutoSave> autoSaves = new List<AutoSave>();
        [SerializeField]
        protected SaveEvent saveEvent = SaveEvent.OnApplicationQuit;
        [SerializeField]
        protected LoadEvent loadEvent = LoadEvent.Start;

        protected virtual void Reset()
        {
            FetchAutoSaves();
            this.settingsPreset = SaveSystemSettingsPreset.DefaultPreset;
        }

        protected virtual void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            if (this.loadEvent == LoadEvent.OnEnable)
            {
                Load();
            }
        }

        protected virtual void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (this.loadEvent == LoadEvent.OnSceneLoaded)
            {
                Load();
            }
        }

        protected virtual void OnSceneUnloaded(Scene scene)
        {
            if (this.saveEvent == SaveEvent.OnSceneUnloaded)
            {
                Save();
            }
        }

        protected virtual void Start()
        {
            if (this.loadEvent == LoadEvent.Start)
            {
                Load();
            }
        }

        protected virtual void Awake()
        {
            if (this.loadEvent == LoadEvent.Awake)
            {
                Load();
            }
        }

        protected virtual void OnApplicationQuit()
        {
            if (this.saveEvent == SaveEvent.OnApplicationQuit)
            {
                Save();
            }
        }

        protected virtual void OnApplicationPause(bool paused)
        {
            if ((saveEvent == SaveEvent.OnApplicationPause || (Application.isMobilePlatform && saveEvent == SaveEvent.OnApplicationQuit)) && paused)
            {
                Save();
            }
        }

        public virtual void FetchAutoSaves()
        {
            this.autoSaves = new List<AutoSave>(FindObjectsOfType<AutoSave>());
        }

        public virtual void AddAutoSave(AutoSave autoSave)
        {
            if (this.autoSaves.Contains(autoSave))
            {
                return;
            }
            this.autoSaves.Add(autoSave);
        }

        public virtual void RemoveAutoSave(AutoSave autoSave)
        {
            if (!this.autoSaves.Contains(autoSave))
            {
                return;
            }
            this.autoSaves.Remove(autoSave);
        }

        public virtual void Save()
        {
            GameObject[] gameObjects = new GameObject[this.autoSaves.Count];
            for (int i = 0; i < this.autoSaves.Count; i++)
            {
                if (this.autoSaves[i] == null)
                {
                    continue;
                }
                gameObjects[i] = this.autoSaves[i].gameObject;
            }
            SaveSystemAPI.SaveAsync(this.identifier, gameObjects, this.settingsPreset.CustomSettings);
        }

        public virtual async void Load()
        {
            if (!await SaveSystemAPI.ExistsAsync(this.identifier))
            {
                return;
            }
            await SaveSystemAPI.LoadAsync<GameObject[]>(this.identifier, this.settingsPreset.CustomSettings);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AutoSaveManager"/> in the current scene.
        /// </summary>
#if UNITY_EDITOR
        [MenuItem("GameObject/Bayat/Save System/Auto Save Manager", false, 10)]
#endif
        public static void CreateNewInstance()
        {
            GameObject go = new GameObject("Auto Save Manager");
            current = go.AddComponent<AutoSaveManager>();
#if UNITY_EDITOR
            Selection.activeGameObject = go;
#endif
        }

    }

}