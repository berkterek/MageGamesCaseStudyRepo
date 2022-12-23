using System.Threading.Tasks;
using UnityEngine;

namespace MageStudy.Managers
{
    public class UnityObjectManager
    {
        static readonly object _locked = new object();
        static UnityObjectManager _unityObjectManager;
        IUnityObjectDal _unityObjectDal;

        private UnityObjectManager()
        {
        }

        public static UnityObjectManager CreateSingleton(UnityCreateType createType)
        {
            lock (_locked)
            {
                if (_unityObjectManager == null)
                {
                    _unityObjectManager = new UnityObjectManager();
                }
            }

            _unityObjectManager.SetCreateType(createType);

            return _unityObjectManager;
        }

        public void SetCreateType(UnityCreateType createType)
        {
            switch (createType)
            {
                case UnityCreateType.Resources:
                    _unityObjectDal = new ResourcesObjectDal();
                    break;
                default:
                    _unityObjectDal = null;
                    break;
            }
        }

        public TScriptableObject GetScriptableObject<TScriptableObject>(string path)
            where TScriptableObject : ScriptableObject
        {
            var result = _unityObjectDal.GetObjectAsync<TScriptableObject>(path);
            return result;
        }
    }

    public interface IUnityObjectDal
    {
         T GetObjectAsync<T>(string path) where T : Object;
    }

    public class ResourcesObjectDal : IUnityObjectDal
    {
        public T GetObjectAsync<T>(string path) where T : Object
        {
            var operation = Resources.LoadAsync<T>(path);
            Task.Yield().GetAwaiter();

            var result = operation.asset as T;
            return result;
        }
    }

    public enum UnityCreateType : byte
    {
        Resources,
        Addressables
    }
}