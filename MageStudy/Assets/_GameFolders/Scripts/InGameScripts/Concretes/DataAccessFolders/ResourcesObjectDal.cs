using System.Threading.Tasks;
using MageStudy.Abstracts.DataAccessFolders;
using UnityEngine;

namespace MageStudy.DataAccessFolders
{
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
}