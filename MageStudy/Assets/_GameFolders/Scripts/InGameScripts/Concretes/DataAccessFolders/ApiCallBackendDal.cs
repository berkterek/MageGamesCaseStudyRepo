using System.Threading.Tasks;
using MageStudy.Abstracts.DataAccessFolders;
using MageStudy.DataEntities;
using MageStudy.Managers;
using MageStudy.ScriptableObjects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace MageStudy.DataAccessFolders
{
    public class ApiCallBackendDal : IBackendDal
    {
        readonly ApiCallUrlDataContainerSO _apiCallUrlDataContainer;

        public int PageLength => _apiCallUrlDataContainer.PageLength;

        public ApiCallBackendDal()
        {
            var unityObjectManager = UnityObjectManager.CreateSingleton(UnityCreateType.Resources);
            _apiCallUrlDataContainer =
                unityObjectManager.GetScriptableObject<ApiCallUrlDataContainerSO>(
                    "DataContainers/LeaderboardUrlDataContainer");
        }

        public async Task<LeaderboardEntityData> GetLeaderboardPageAsync(int pageCount)
        {
            string url = _apiCallUrlDataContainer.GetUrlByIndex(pageCount);

            if (string.IsNullOrEmpty(url))
            {
                Debug.Log("<color=red>Url is empty</color>");
            }
            else
            {
                using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
                {
                    webRequest.SendWebRequest();

                    while (!webRequest.isDone)
                    {
                        await Task.Yield();
                    }

                    if (UnityWebRequest.Result.Success == webRequest.result)
                    {
                        try
                        {
                            string getResult = webRequest.downloadHandler.text;
                            LeaderboardEntityData apiResult = JsonConvert.DeserializeObject<LeaderboardEntityData>(getResult);
                            Debug.Log($"Api call result count => <color=red>{apiResult.Data.Count}</color>");
                            return apiResult;
                        }
                        catch
                        {
                            Debug.LogError("Api call failed and throw exception");
                        }
                    }
                }
            }

            return null;
        }
    }
}