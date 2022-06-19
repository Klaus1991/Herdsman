using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Infrastructure.Utils;
using Infrastructure.Factory;
using System;
using System.Linq;
using Infrastructure.Data;

namespace Infrastructure.UnityContext.UI
{
    public class UIView : MonoBehaviour
    {
        private static readonly string InstanceName = "[UIView]";
        private static readonly string CanvasPath = "CanvasMain";
        public static readonly string CanvasTag = "CanvasMain";

        public static event Action<GameObject> OnShow;

        public static int ActiveCount = Current.GetActiveWindows().Length;

        private static UIView current;
        private static UIView Current
        {
            get
            {
                if (current == null)
                {
                    current = new GameObject(InstanceName).AddComponent<UIView>();
                }
                return current;
            }
        }

        public static GameObject ShowWindow(GameObject uiPrefab)
        {
            var objInstanceID = uiPrefab.GetInstanceID();
            var window = Current.ShowOrCreateWindows(objInstanceID, uiPrefab);
            OnShow?.Invoke(window);
            return window;
        }

        public static void HideWindow(GameObject uiPrefab)
        {
            var objInstanceID = uiPrefab.GetInstanceID();
            Current.HideWindow(objInstanceID);
        }

        public static void HideAll()
        {
            Current.HideAllWindows();
        }

        public static GameObject GetInstance(GameObject uiPrefab)
        {
            var objInstanceID = uiPrefab.GetInstanceID();
            return Current.GetInstance(objInstanceID);
        }

        public static void SetCamera(Camera camera)
        {
            RootCanvas.GetComponent<Canvas>().worldCamera = camera;
        }

        private Dictionary<int, GameObject> WindowsDictionary = new Dictionary<int, GameObject>();

        public static GameObject RootCanvas => Current.RootWindow.gameObject;

        private Transform rootWindow;
        private Transform RootWindow
        {
            get
            {
                if (rootWindow == null)
                {
                    GameObject canvas = GameObject.FindGameObjectWithTag(CanvasTag);
                    if (canvas == null)
                    {
                        var dataProvider = new ResourcesDataProvider();
                        var canvasPrefab = dataProvider.Load<GameObject>(CanvasPath);
                        var newCanvas = Instantiate(canvasPrefab);
                        rootWindow = newCanvas.transform;
                    }
                    else
                    {
                        rootWindow = canvas.gameObject.transform;
                    }
                }
                return rootWindow;
            }
        }

        private void OnDestroy() => rootWindow = null;


        public GameObject GetInstance(int id)
        {
            return WindowsDictionary.ContainsKey(id) ? WindowsDictionary[id] : null;
        }

        public GameObject ShowOrCreateWindows(int id, GameObject prefab)
        {
            if (WindowsDictionary.ContainsKey(id))
            {
                var window = WindowsDictionary[id];
                var rect = window.GetComponent<RectTransform>();
                if (rect != null) rect.SetAsLastSibling();
                window.SetActive(true);
                return window;
            }
            else
            {
                var newWindow = Instantiate(prefab, RootWindow);
                WindowsDictionary.Add(id, newWindow);
                var rect = newWindow.GetComponent<RectTransform>();
                if (rect != null) rect.SetAsLastSibling();
                return newWindow;
            }
        }

        public GameObject [] GetActiveWindows()
        {
            return WindowsDictionary.Select(x=>x.Value).Where(x => x.activeInHierarchy).ToArray();
        }

        public void HideAllWindows()
        {
            foreach(var keyPair in WindowsDictionary)
            {
                HideWindow(keyPair.Key);
            }
        }

        public void HideWindow(int id)
        {
            if (WindowsDictionary.ContainsKey(id))
            {
                var window = WindowsDictionary[id];
                window.SetActive(false);
            }
            else
            {
                InternalLogger.Error(ErrorDefinations.WINDOWS_NOT_FOUND);
            }
        }
    }
}