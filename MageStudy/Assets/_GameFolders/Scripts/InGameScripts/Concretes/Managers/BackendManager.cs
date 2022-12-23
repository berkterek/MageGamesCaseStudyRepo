using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MageStudy.Abstracts.DataAccessFolders;
using MageStudy.Abstracts.Helpers;
using MageStudy.DataAccessFolders;
using MageStudy.DataEntities;

namespace MageStudy.Managers
{
    public class BackendManager : MonoSingletonDontDestroy<BackendManager>
    {
        IBackendDal _backendDal;

        void Awake()
        {
            SetSingleton(this);

            _backendDal = new ApiCallBackendDal();
        }

        public async Task<List<LeaderboardPlayerEntityData>> GetLeaderboardByPageCountAsync(int page)
        {
             var apiResult = await _backendDal.GetLeaderboardPageAsync(page);
             return apiResult.Data.ToList();
        }
    }
}