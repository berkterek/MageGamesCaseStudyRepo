using MageStudy.Abstracts.DataAccessFolders;
using MageStudy.DataAccessFolders;
using MageStudy.Enums;
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
}