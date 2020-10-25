using UnityEngine;

namespace Simple {
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {
        static bool _isInited = false;
        static T _instance;
        public static T Instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType(typeof(T)) as T;
                    if (_instance == null) {
                        _instance = new GameObject("(Singleton)" + typeof(T).FullName).AddComponent<T>();
                    }
                    if (!_isInited) {
                        _instance.Init();
                        _isInited = true;
                    }
                }
                return _instance;

            }
        }

        private void Awake() {
            if (_instance == null) {
                _instance = this as T;
            }
            else if (_instance != this) {
                DestroyImmediate(this);
                throw new System.Exception("Duplicated instancing of Singleton");
            }
            if (!_isInited) {
                DontDestroyOnLoad(this);
                Init();
                _isInited = true;
            }
        }

        protected virtual void Init() {

        }
    }
}

