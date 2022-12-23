using MageStudy.Abstracts.Helpers;
using UnityEngine;

namespace MageStudy.Managers
{
    public class GameManager : MonoSingletonDontDestroy<GameManager>
    {
        void Awake()
        {
            SetSingleton(this);
            Application.targetFrameRate = 60;
        }

        public void LoadGameScene()
        {
            
        }
    }    
}