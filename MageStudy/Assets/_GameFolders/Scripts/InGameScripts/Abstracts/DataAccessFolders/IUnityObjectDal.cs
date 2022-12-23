using UnityEngine;

namespace MageStudy.Abstracts.DataAccessFolders
{
    public interface IUnityObjectDal
    {
        T GetObjectAsync<T>(string path) where T : Object;
    }
}