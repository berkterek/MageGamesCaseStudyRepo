using MageStudy.Abstracts.Uis;
using MageStudy.ScriptableObjects;
using UnityEngine;

namespace MageStudy.Uis
{
    public class LeaderboardOpenButton : BaseButton
    {
        [SerializeField] GameEvent _leaderboardOpenEvent;
        
        protected override void HandleOnButtonClicked()
        {
            _leaderboardOpenEvent.InvokeEvents();
        }
    }    
}

