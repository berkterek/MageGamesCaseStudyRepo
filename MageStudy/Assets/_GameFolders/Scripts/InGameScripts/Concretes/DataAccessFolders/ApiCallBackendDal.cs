using System.Threading;
using System.Threading.Tasks;
using MageStudy.Abstracts.DataAccessFolders;
using MageStudy.DataEntities;
using MageStudy.Enums;
using MageStudy.Managers;
using MageStudy.ScriptableObjects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace MageStudy.DataAccessFolders
{
    public partial class ApiCallBackendDal : IBackendDal
    {
        readonly ApiCallUrlDataContainerSO _leaderboardUrlDataContainer;
        readonly ApiCallUrlDataContainerSO _questionUrlDataContainer;

        public int PageLength => _leaderboardUrlDataContainer.PageLength;

        public ApiCallBackendDal()
        {
            var unityObjectManager = UnityObjectManager.CreateSingleton(UnityCreateType.Resources);
            
            _leaderboardUrlDataContainer =
                unityObjectManager.GetScriptableObject<ApiCallUrlDataContainerSO>(
                    "DataContainers/LeaderboardUrlDataContainer");

            _questionUrlDataContainer =
                unityObjectManager.GetScriptableObject<ApiCallUrlDataContainerSO>(
                    "DataContainers/QuestionsUrlDataContainer");
        }

        public async Task<LeaderboardEntityData> GetLeaderboardPageAsync(int pageCount)
        {
            var result = await GetGenericApiCall<LeaderboardEntityData>(_leaderboardUrlDataContainer, pageCount);
            return result;
        }

        public async Task<QuestionsEntityData> GetQuestions()
        {
            var result = await GetGenericApiCall<QuestionsEntityData>(_questionUrlDataContainer);
            return result;

        }

        private async Task<T> GetGenericApiCall<T>(ApiCallUrlDataContainerSO dataContainerSo, int index = 0)
        {
            string url = dataContainerSo.GetUrlByIndex(index);

            if (string.IsNullOrEmpty(url))
            {
                Debug.Log("<color=red>Url is empty</color>");
            }
            else
            {
                using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
                {
                    webRequest.SendWebRequest();

                    CancellationTokenSource token = new CancellationTokenSource();
                    while (!webRequest.isDone)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        
                        Task.Yield();    
                    }

                    if (UnityWebRequest.Result.Success == webRequest.result)
                    {
                        try
                        {
                            string getResult = webRequest.downloadHandler.text;
                            var apiResult = JsonConvert.DeserializeObject<T>(getResult);
                            return apiResult;
                        }
                        catch
                        {
                            Debug.LogError("Api call failed and throw exception");
                        }
                    }
                }
            }

            return default;
        }
    }
}