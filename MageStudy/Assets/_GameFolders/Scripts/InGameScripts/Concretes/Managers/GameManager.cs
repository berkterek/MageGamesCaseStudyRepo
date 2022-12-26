using MageStudy.Abstracts.Helpers;
using UnityEngine;

namespace MageStudy.Managers
{
    public class GameManager : MonoSingletonDontDestroy<GameManager>
    {
        public event System.Action<int> OnGameEnded;
        
        void Awake()
        {
            SetSingleton(this);
            Application.targetFrameRate = 60;
        }

        public void LoadGameScene()
        {
            
        }

        public void LoadMenuScene()
        {
            
        }

        public void GameEnded(int score)
        {
            OnGameEnded?.Invoke(score);
        }
    }    
}