using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace MageStudy.DataEntities
{
    public class UnitySceneLoaderDal : ISceneLoaderDal
    {
        public void LoadSceneByName(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
        }
    }

    public interface ISceneLoaderDal
    {
        void LoadSceneByName(string sceneName);
    }
}