using MageStudy.Abstracts.DataAccessFolders;
using MageStudy.Abstracts.Helpers;
using MageStudy.DataAccessFolders;

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
    }
}