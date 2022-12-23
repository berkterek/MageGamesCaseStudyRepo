using MageStudy.Controllers;
using UnityEngine;

namespace MageStudy.Managers
{
    public class LeaderboardSlotManager : MonoBehaviour
    {
        [SerializeField] LeaderboardSlotController[] _slots;

        void Start()
        {
            if (BackendManager.Instance == null) return;
            var entities = BackendManager.Instance.GetLeaderboardByPageCountAsync(0).Result;
            
            int count = entities.Count;
            for (int i = 0; i < count; i++)
            {
                _slots[i].Bind(entities[i]);
            }
        }

        void OnValidate()
        {
            if (_slots == null)
            {
                _slots = GetComponentsInChildren<LeaderboardSlotController>();
            }
        }
    }    
}