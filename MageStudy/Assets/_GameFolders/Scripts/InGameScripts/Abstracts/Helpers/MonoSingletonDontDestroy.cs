using UnityEngine;

namespace MageStudy.Abstracts.Helpers
{
    public abstract class MonoSingletonDontDestroy<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void SetSingleton(T instance)
        {
            if (Instance == null)
            {
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}