using System.Collections;
using MageStudy.Controllers;
using UnityEngine;

namespace MageStudy.Managers
{
    public class LeaderboardPageSlotManager : MonoBehaviour
    {
        [SerializeField] PageSlotController _pageSlotPrefab;

        IEnumerator Start()
        {
            while (BackendManager.Instance == null) yield return null;
            while (BackendManager.Instance.PageMaxCount == 0) yield return null;

            int count = BackendManager.Instance.PageMaxCount;
            for (int i = 0; i < count; i++)
            {
                var newPage = Instantiate(_pageSlotPrefab, transform);
                newPage.Bind(i + 1);
            }
        }
    }    
}

