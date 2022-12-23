using MageStudy.Controllers;
using MageStudy.Helpers;
using MageStudy.ScriptableObjects.GameEventListeners;
using UnityEngine;

namespace MageStudy.Managers
{
    public class LeaderboardSlotManager : MonoBehaviour
    {
        [SerializeField] NormalGameEventListener _normalGameEventListener;
        [SerializeField] LeaderboardSlotController[] _slots;

        void Start()
        {
            if (BackendManager.Instance == null) return;
            GetLeaderboard(0);
        }

        void OnEnable()
        {
            _normalGameEventListener.ParameterEventWithObject += HandleOnParameterEvent;
        }

        void OnDisable()
        {
            _normalGameEventListener.ParameterEventWithObject -= HandleOnParameterEvent;
        }

        void OnValidate()
        {
            if (_slots == null)
            {
                _slots = GetComponentsInChildren<LeaderboardSlotController>();
            }
            
            this.GetReference<NormalGameEventListener>(ref _normalGameEventListener);
        }
        
        void HandleOnParameterEvent(object value)
        {
            int pageNumber = (int)value;
            GetLeaderboard(pageNumber-1);
        }

        void GetLeaderboard(int pageNumber)
        {
            var entities = BackendManager.Instance.GetLeaderboardByPageCountAsync(pageNumber).Result;
            
            int count = entities.Count;
            for (int i = 0; i < count; i++)
            {
                _slots[i].Bind(entities[i]);
            }
        }
    }    
}