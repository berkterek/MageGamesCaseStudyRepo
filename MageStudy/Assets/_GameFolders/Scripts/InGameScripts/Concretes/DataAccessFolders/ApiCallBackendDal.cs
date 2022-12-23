using MageStudy.Abstracts.DataAccessFolders;
using MageStudy.Managers;
using MageStudy.ScriptableObjects;

namespace MageStudy.DataAccessFolders
{
    public class ApiCallBackendDal : IBackendDal
    {
        readonly ApiCallUrlDataContainerSO _apiCallUrlDataContainer;
        
        public ApiCallBackendDal()
        {
            var unityObjectManager = UnityObjectManager.CreateSingleton(UnityCreateType.Resources);
            _apiCallUrlDataContainer = unityObjectManager.GetScriptableObject<ApiCallUrlDataContainerSO>("DataContainers/LeaderboardUrlDataContainer");
        }
        
        public void GetLeaderboardPage(int pageCount)
        {
            
        }
    }
}