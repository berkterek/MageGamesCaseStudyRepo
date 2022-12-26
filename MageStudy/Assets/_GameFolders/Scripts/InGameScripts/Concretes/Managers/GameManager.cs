using MageStudy.Abstracts.Helpers;
using MageStudy.DataEntities;
using UnityEngine;

namespace MageStudy.Managers
{
    public class GameManager : MonoSingletonDontDestroy<GameManager>
    {
        ISceneLoaderDal _sceneLoaderDal;
        
        public event System.Action<int> OnGameEnded;
        
        void Awake()
        {
            SetSingleton(this);
            Application.targetFrameRate = 60;

            _sceneLoaderDal = new UnitySceneLoaderDal();
        }

        public void LoadGameScene()
        {
            _sceneLoaderDal.LoadSceneByName("Game");
        }

        public void LoadMenuScene()
        {
            _sceneLoaderDal.LoadSceneByName("Menu");
        }

        public void GameEnded(int score)
        {
            OnGameEnded?.Invoke(score);
        }
    }
}