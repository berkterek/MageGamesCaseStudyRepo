using MageStudy.Abstracts.Uis;
using TMPro;
using UnityEngine;
using MageStudy.Helpers;
using MageStudy.ScriptableObjects;

namespace MageStudy.Controllers
{
    public class PageSlotController : BaseButton
    {
        [SerializeField] GameEvent _leaderboardPageEvent;
        [SerializeField] TMP_Text _pageCountText;

        protected override void OnValidate()
        {
            base.OnValidate();
            this.GetReferenceInChildren<TMP_Text>(ref _pageCountText);
        }

        protected override void HandleOnButtonClicked()
        {
            _leaderboardPageEvent.InvokeEventsWithObject(int.Parse(_pageCountText.text));
        }

        public void Bind(int pageCount)
        {
            _pageCountText.text = pageCount.ToString();
        }
    }    
}